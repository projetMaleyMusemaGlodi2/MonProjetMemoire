import 'package:flutter/material.dart';
//import 'package:http/http.dart' show get;
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:mobilepaie_trans/Classes/pub.dart';

class ParametrePrix extends StatefulWidget {
  final String menu;

  const ParametrePrix({Key key, this.menu}) : super(key: key);
  @override
  _ParametrePrixState createState() => _ParametrePrixState();
}

class _ParametrePrixState extends State<ParametrePrix> {
  final _scaffoldKey = GlobalKey<ScaffoldState>();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
        elevation: 0.0,
        backgroundColor: Colors.blue,
        title: Text("PARAMETRE PRIX"),
      ),
      body: new Container(
          child: new FutureBuilder<List<PrixFull>>(
              future: downloadJSON(),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  List<PrixFull> billetsFull = snapshot.data;

                  return CustomListView(billetsFull,widget.menu);
                } else if (snapshot.hasError) {
                  return Text('${snapshot.error}');
                }

                return Align(
                  alignment: Alignment.center,
                  child: new CircularProgressIndicator());
              })),
    );
  }
}

class PrixFull {
  final String id;
  final String prix;

  PrixFull({
    Key key,
    this.id,
    this.prix,
    });
  factory PrixFull.fromJson(Map<String, dynamic> jsonData) {
    return PrixFull(
      id: jsonData['id'],
      prix: jsonData['Prix'],
      );
  }
}

class CustomListView extends StatelessWidget {
  final List<PrixFull> billetFull;
  final String menu;
  CustomListView(this.billetFull, this.menu);
  Widget build(context) {
    return ListView.builder(
        itemCount: billetFull.length,
        itemBuilder: (context, int currentIndex) {
          return createViewItem(billetFull[currentIndex], context,menu);
        });
  }

  Widget createViewItem(PrixFull prixFull, BuildContext context,String menu) {
    return new ListTile(
      contentPadding: EdgeInsets.all(1.0),
      title: new Card(
        elevation: 3.0,
        child: Container(
          child: Column(
            children: <Widget>[
              Padding(
                padding: const EdgeInsets.symmetric(vertical: 15.0),
                child: Column(
                  children: <Widget>[
                    Divider(),
                    Row(
                      mainAxisSize: MainAxisSize.max,
                      mainAxisAlignment: MainAxisAlignment.spaceAround,
                      children: <Widget>[
                        Expanded(
                          child: Column(
                            children: <Widget>[
                              ListTile(
                                  title: Text(
                                    "${prixFull.prix}",
                                    style: TextStyle(color: Colors.blue),
                                  ),
                                 leading: Text("#00${prixFull.id}")
                          ),])
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
      onTap: () {
        // var route = new MaterialPageRoute(
        //       builder: (BuildContext context) =>
        //       new ListeChauffeur(),
        // );
        // Navigator.of(context).push(route);      
      },
    );
  }
}

Future<List<PrixFull>> downloadJSON() async {
  //final jsonEndpoint = PubCon.cheminPhp + "GetHistoriqueVoyageFuture.php";
  final response = await http.post(
      PubCon.cheminPhp + "GetPrixAll.php",body: {});
  //var data = json.decode(response.body);
  if (response.statusCode == 200) {
    //if(data.length != 0){
    List billetsFull = json.decode(response.body);
    return billetsFull
        .map((billetsFull) => new PrixFull.fromJson(billetsFull))
        .toList();
  } else {
    throw Exception('Nous n\'avons pas pu telecharger toutes les donnees.');
  }
}

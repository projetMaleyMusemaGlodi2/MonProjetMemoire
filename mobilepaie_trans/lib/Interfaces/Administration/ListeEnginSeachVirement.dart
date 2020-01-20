import 'package:flutter/material.dart';
//import 'package:http/http.dart' show get;
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/ListeEngins.dart';
//import 'package:mobilepaie_trans/Interfaces/SeachChauffeur.dart';

class ListeEnginSearchVirement extends StatefulWidget {
  final String menu;
  const ListeEnginSearchVirement({Key key, this.menu}) : super(key: key);
  @override
  _ListeEnginSearchVirementState createState() => _ListeEnginSearchVirementState();
}

class _ListeEnginSearchVirementState extends State<ListeEnginSearchVirement> {
  final _scaffoldKey = GlobalKey<ScaffoldState>();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
        elevation: 0.0,
        backgroundColor: Colors.blue,
        title: Text("ENGIN DONNATEUR"),
      ),
      body: new Container(
          child: new FutureBuilder<List<MesEnginsSearchFull>>(
              future: downloadJSON(),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  List<MesEnginsSearchFull> billetsFull = snapshot.data;

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

class MesEnginsSearchFull {
  final String id;
  final String detailEngin;

  MesEnginsSearchFull({
    Key key,
    this.id,
    this.detailEngin,
    });
  factory MesEnginsSearchFull.fromJson(Map<String, dynamic> jsonData) {
    return MesEnginsSearchFull(
      id: jsonData['id'],
      detailEngin: jsonData['detailEngin'],
      );
  }
}

class CustomListView extends StatelessWidget {
  final List<MesEnginsSearchFull> billetFull;
  final String menu;
  CustomListView(this.billetFull, this.menu);
  Widget build(context) {
    return ListView.builder(
        itemCount: billetFull.length,
        itemBuilder: (context, int currentIndex) {
          return createViewItem(billetFull[currentIndex], context,menu);
        });
  }

  Widget createViewItem(MesEnginsSearchFull enginFull, BuildContext context,String menu) {
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
                                    "${enginFull.detailEngin}",
                                    style: TextStyle(color: Colors.blue),
                                  ),
                                  leading: Text("#00${enginFull.id}")
                            
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
        if(PubCon.typeUser=='agent' && PubCon.typeopAdmin=="virement"){
              PubCon.idEngins=enginFull.id.toString();
              PubCon.detailEngin=enginFull.detailEngin.toString();
              var route = new MaterialPageRoute(
              builder: (BuildContext context) =>
              new ListeEngins(),
        );
        Navigator.of(context).push(route);
        }         
      },
    );
  }
}

Future<List<MesEnginsSearchFull>> downloadJSON() async {
  //final jsonEndpoint = PubCon.cheminPhp + "GetHistoriqueVoyageFuture.php";
  final response = await http.post(
      PubCon.cheminPhp + "GetEnginSearchVirement.php",body: {});
  //var data = json.decode(response.body);
  if (response.statusCode == 200) {
    //if(data.length != 0){
    List billetsFull = json.decode(response.body);
    return billetsFull
        .map((billetsFull) => new MesEnginsSearchFull.fromJson(billetsFull))
        .toList();
  } else {
    throw Exception('Nous n\'avons pas pu telecharger toutes les donnees.');
  }
}

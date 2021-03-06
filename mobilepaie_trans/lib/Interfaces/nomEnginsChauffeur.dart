import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/compteChauffeur.dart';

class NosEnginsChauffeur extends StatefulWidget {
  final String menu;

  const NosEnginsChauffeur({Key key, this.menu}) : super(key: key);
  @override
  _NosEnginsChauffeurState createState()
   {
      return new  _NosEnginsChauffeurState();
   }
}

class _NosEnginsChauffeurState extends State<NosEnginsChauffeur> {
  final _scaffoldKey = GlobalKey<ScaffoldState>();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
        elevation: 0.0,
        backgroundColor: Colors.blue,
        title: Text("LES ENGINS"),
      ),
      body: new Container(
          child: new FutureBuilder<List<NosEnginsChauffeurFull>>(
              future: downloadJSON(),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  List<NosEnginsChauffeurFull> billetsFull = snapshot.data;

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

class NosEnginsChauffeurFull {
  final String id;
  final String detailEngin,
      compte;

  NosEnginsChauffeurFull({
    Key key,
    this.id,
    this.detailEngin,
    this.compte,
  });
  factory NosEnginsChauffeurFull.fromJson(Map<String, dynamic> jsonData) {
    return NosEnginsChauffeurFull(
      id: jsonData['id'],
      detailEngin: jsonData['detailEngin'],
      compte: jsonData['CompteBus'],
    );
  }
}

class CustomListView extends StatelessWidget {
  final List<NosEnginsChauffeurFull> billetFull;
  final String menu;
  CustomListView(this.billetFull, this.menu);
  Widget build(context) {
    return ListView.builder(
        itemCount: billetFull.length,
        itemBuilder: (context, int currentIndex) {
          return createViewItem(billetFull[currentIndex], context,menu);
        });
  }

  Widget createViewItem(NosEnginsChauffeurFull enginFull, BuildContext context,String menu) {
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
                                  subtitle: Text("${enginFull.compte}"),
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
        if(PubCon.typeUser=='chauffeur'){
              PubCon.userSolde=enginFull.compte.toString();
              var route = new MaterialPageRoute(
              builder: (BuildContext context) =>
              new COmpteChauffeur(),
        );
        Navigator.of(context).push(route);
        }
        //  else if(PubCon.typeUser=='chauffeur'){
        //        PubCon.userSolde=enginFull.compte.toString();
        //        var route = new MaterialPageRoute(
        //        builder: (BuildContext context) =>
        //       new COmpteChauffeur(),
        //  );
        // Navigator.of(context).push(route);
        //  } 
        // else if(menu=='rapport'){
        //   Navigator.push(
        //           context,
        //           MaterialPageRoute(
        //               builder: (context) => MyReport(idEngin: enginFull.codeEngin,menuTrie: 'engin',)));
        // }

        
      },
    );
  }
}

Future<List<NosEnginsChauffeurFull>> downloadJSON() async {
  //final jsonEndpoint = PubCon.cheminPhp + "GetHistoriqueVoyageFuture.php";
  final response = await http.post(
      PubCon.cheminPhp + "GetEnginSelonChauffeur.php",
      body: {"refChauffeur": PubCon.userId.toString()});
  //var data = json.decode(response.body);
  if (response.statusCode == 200) {
    //if(data.length != 0){
    List billetsFull = json.decode(response.body);
    return billetsFull
        .map((billetsFull) => new NosEnginsChauffeurFull.fromJson(billetsFull))
        .toList();
  } else {
    throw Exception('Nous n\'avons pas pu telecharger toutes les donnees.');
  }
}

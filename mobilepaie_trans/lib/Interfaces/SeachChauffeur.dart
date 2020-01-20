import 'package:flutter/material.dart';
//import 'package:http/http.dart' show get;
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/addAffectChaffeur.dart';

class ListeChauffeur extends StatefulWidget {
  final String menu;

  const ListeChauffeur({Key key, this.menu}) : super(key: key);
  @override
  _ListeChauffeurState createState() => _ListeChauffeurState();
}

class _ListeChauffeurState extends State<ListeChauffeur> {
  final _scaffoldKey = GlobalKey<ScaffoldState>();
  @override
  Widget build(BuildContext context) {
     return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
        elevation: 0.0,
        backgroundColor: Colors.blue,
        title: Text("LES CHAUFFEURS"),
      ),
      body: new Container(
          child: new FutureBuilder<List<ChauffeurFull>>(
              future: downloadJSON(),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  List<ChauffeurFull> billetsFull = snapshot.data;

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

class ChauffeurFull {
  final String id;
  final String noms;
  final String imageChauffeur;

  ChauffeurFull({
    Key key,
    this.id,
    this.noms,
    this.imageChauffeur,
    });
  factory ChauffeurFull.fromJson(Map<String, dynamic> jsonData) {
    return ChauffeurFull(
      id: jsonData['id'],
      noms: jsonData['noms'],
      imageChauffeur: jsonData['image'],
      );
  }
}

class CustomListView extends StatelessWidget {
  final List<ChauffeurFull> billetFull;
  final String menu;
  CustomListView(this.billetFull, this.menu);
  Widget build(context) {
    return ListView.builder(
        itemCount: billetFull.length,
        itemBuilder: (context, int currentIndex) {
          return createViewItem(billetFull[currentIndex], context,menu);
        });
  }

  Widget createViewItem(ChauffeurFull chauffeurFull, BuildContext context,String menu) {
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
                                    "${chauffeurFull.noms}",
                                    style: TextStyle(color: Colors.blue),
                                  ),
                                  leading: Text("#00${chauffeurFull.id}")
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
        if(PubCon.typeUser=='proprietaire'){
              PubCon.idChauffeur=chauffeurFull.id.toString();
              PubCon.nomsChauffeur=chauffeurFull.noms.toString();
              PubCon.imageChauffeur=chauffeurFull.imageChauffeur;
              var route = new MaterialPageRoute(
              builder: (BuildContext context) =>
              new AffectationChauffeur(),
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

Future<List<ChauffeurFull>> downloadJSON() async {
  //final jsonEndpoint = PubCon.cheminPhp + "GetHistoriqueVoyageFuture.php";
  final response = await http.post(
      PubCon.cheminPhp + "GetChauffeurAll.php", body: {});
  //var data = json.decode(response.body);
  if (response.statusCode == 200) {
    //if(data.length != 0){
    List billetsFull = json.decode(response.body);
    return billetsFull
        .map((billetsFull) => new ChauffeurFull.fromJson(billetsFull))
        .toList();
  } else {
    throw Exception('Nous n\'avons pas pu telecharger toutes les donnees.');
  }
}
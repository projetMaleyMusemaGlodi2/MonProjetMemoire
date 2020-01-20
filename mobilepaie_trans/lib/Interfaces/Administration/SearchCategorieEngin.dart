import 'package:flutter/material.dart';
//import 'package:http/http.dart' show get;
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/AddEngins.dart';
//import 'package:mobilepaie_trans/Interfaces/Administration/Paiement.dart';

class ListeCategorieEngin extends StatefulWidget {

  final String menu;

  const ListeCategorieEngin({Key key, this.menu}) : super(key: key);
  @override
  _ListeCategorieEnginState createState() => _ListeCategorieEnginState();
}

class _ListeCategorieEnginState extends State<ListeCategorieEngin> {
  final _scaffoldKey = GlobalKey<ScaffoldState>();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
        elevation: 0.0,
        backgroundColor: Colors.blue,
        title: Text("LES CATEGORIES DES ENGINS"),
      ),
      body: new Container(
          child: new FutureBuilder<List<ListeCategorieFull>>(
              future: downloadJSON(),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  List<ListeCategorieFull> billetsFull = snapshot.data;

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

class ListeCategorieFull {
  final String id;
  final String designation;

  ListeCategorieFull({
    Key key,
    this.id,
    this.designation
   });
  factory ListeCategorieFull.fromJson(Map<String, dynamic> jsonData) {
    return ListeCategorieFull(
      id: jsonData['id'],
      designation: jsonData['designation']      
    );
  }
}

class CustomListView extends StatelessWidget {
  final List<ListeCategorieFull> billetFull;
  final String menu;
  CustomListView(this.billetFull, this.menu);
  Widget build(context) {
    return ListView.builder(
        itemCount: billetFull.length,
        itemBuilder: (context, int currentIndex) {
          return createViewItem(billetFull[currentIndex], context,menu);
        });
  }

  Widget createViewItem(ListeCategorieFull categorieFull, BuildContext context,String menu) {
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
                                    "${categorieFull.designation}",
                                    style: TextStyle(color: Colors.blue),
                                  ),
                                  subtitle: Text("${categorieFull.designation}"),
                                  leading: Text("#00${categorieFull.id}")
                            
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
              PubCon.designationCat=categorieFull.designation.toString();
              PubCon.idCat=categorieFull.id.toString();
              var route = new MaterialPageRoute(
              builder: (BuildContext context) => new AddEngin(),
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

Future<List<ListeCategorieFull>> downloadJSON() async {
  //final jsonEndpoint = PubCon.cheminPhp + "GetHistoriqueVoyageFuture.php";
  final response = await http.post(PubCon.cheminPhp + "GetCategorie.php", body: {    
  });
  //var data = json.decode(response.body);
  if (response.statusCode == 200) {
    //if(data.length != 0){
    List billetsFull = json.decode(response.body);
    return billetsFull
        .map((billetsFull) => new ListeCategorieFull.fromJson(billetsFull))
        .toList();
  } else {
    throw Exception('Nous n\'avons pas pu telecharger toutes les donnees.');
  }
}

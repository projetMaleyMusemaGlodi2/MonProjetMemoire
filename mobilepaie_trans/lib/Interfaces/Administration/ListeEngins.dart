
import 'package:flutter/material.dart';
//import 'package:http/http.dart' show get;
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/AddRetraitBus.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/AddVirerementEngin.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/Paiement.dart';

class ListeEngins extends StatefulWidget {
  final String menu;

  const ListeEngins({Key key, this.menu}) : super(key: key);
  @override
  _ListeEnginsState createState() => _ListeEnginsState();
}

class _ListeEnginsState extends State<ListeEngins> {
  final _scaffoldKey = GlobalKey<ScaffoldState>();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
        elevation: 0.0,
        backgroundColor: Colors.blue,
        title: Text((PubCon.typeUser=='agent'  && PubCon.typeopAdmin=='virement')  ? "ENGIN RECEPTEUR":"LES ENGINS"),
      ),
      body: new Container(
          child: new FutureBuilder<List<ListeEnginsFull>>(
              future: downloadJSON(),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  List<ListeEnginsFull> billetsFull = snapshot.data;

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

class ListeEnginsFull {
  final String id;
  final String detailEngin,
      compte;

  ListeEnginsFull({
    Key key,
    this.id,
    this.detailEngin,
    this.compte,
  });
  factory ListeEnginsFull.fromJson(Map<String, dynamic> jsonData) {
    return ListeEnginsFull(
      id: jsonData['id'],
      detailEngin: jsonData['detailEngin'],
      compte: jsonData['CompteBus'],
    );
  }
}

class CustomListView extends StatelessWidget {
  final List<ListeEnginsFull> billetFull;
  final String menu;
  CustomListView(this.billetFull, this.menu);
  Widget build(context) {
    return ListView.builder(
        itemCount: billetFull.length,
        itemBuilder: (context, int currentIndex) {
          return createViewItem(billetFull[currentIndex], context,menu);
        });
  }

  Widget createViewItem(ListeEnginsFull enginFull, BuildContext context,String menu) {
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
        if(PubCon.typeUser=='agent'  && PubCon.typeopAdmin=='paiement'){
              PubCon.userSolde=enginFull.compte.toString();
              PubCon.compteEngins=enginFull.compte.toString();
              PubCon.refAffectation=enginFull.id.toString();
              PubCon.detailAffectation=enginFull.detailEngin.toString();
              var route = new MaterialPageRoute(
              builder: (BuildContext context) =>
              new QRscanner(),
        );
        Navigator.of(context).push(route);
        }
        else if(PubCon.typeUser=='agent'  && PubCon.typeopAdmin=='retrait'){
              PubCon.userSolde=enginFull.compte.toString();
              PubCon.compteEngins=enginFull.compte.toString();
              PubCon.refAffectation=enginFull.id.toString();
              PubCon.detailAffectation=enginFull.detailEngin.toString();
              var route = new MaterialPageRoute(
              builder: (BuildContext context) =>
              new AddRetraitBus(),
        );
        Navigator.of(context).push(route);
        }
        else if(PubCon.typeUser=='agent'  && PubCon.typeopAdmin=='virement'){
              PubCon.userSolde=enginFull.compte.toString();
              PubCon.compteEngins=enginFull.compte.toString();
              PubCon.refAffectation=enginFull.id.toString();
              PubCon.detailAffectation=enginFull.detailEngin.toString();
              var route = new MaterialPageRoute(
              builder: (BuildContext context) =>
              new AddVirementEngin(),
        );
        Navigator.of(context).push(route);
        }

        
      },
    );
  }
}

Future<List<ListeEnginsFull>> downloadJSON() async {
  //final jsonEndpoint = PubCon.cheminPhp + "GetHistoriqueVoyageFuture.php";
  final response = await http.post(PubCon.cheminPhp + "GetEnginAll.php", body: { });
  //var data = json.decode(response.body);
  if (response.statusCode == 200) {
    //if(data.length != 0){
    List billetsFull = json.decode(response.body);
    return billetsFull
        .map((billetsFull) => new ListeEnginsFull.fromJson(billetsFull))
        .toList();
  } else {
    throw Exception('Nous n\'avons pas pu telecharger toutes les donnees.');
  }
}

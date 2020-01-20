import 'dart:io';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobilepaie_trans/Classes/components.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/profilClient.dart';
import 'package:mobilepaie_trans/Interfaces/rapportCourseClient.dart';

class MonCompte extends StatefulWidget {
  @override
  _MonCompteState createState() => _MonCompteState();
}

class _MonCompteState extends State<MonCompte> {
@override
void initState() { 
  super.initState();
  
}

  TextEditingController user= new TextEditingController(),
      solde = new TextEditingController(),
      prenom = new TextEditingController(),
      nom = new TextEditingController();
      //=================================================================================================
      File _image;

final f=new DateFormat('yyyy-MM-dd');
DateTime date=DateTime.now();
     
bool _autoValidate = false;

  
final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  @override
  Widget build(BuildContext context) {
    user.text=PubCon.username;
    nom.text=PubCon.userNomComplet;    
    solde.text=PubCon.userSolde;
        return Scaffold(
      appBar: AppBar(centerTitle: false,
        title:new Text("Mon Compte",style: TextStyle(color: Colors.white,fontWeight: FontWeight.bold,)),
        backgroundColor: Colors.blue,
          actions: <Widget>[
            new Stack(
              alignment: Alignment.topCenter,
              children: <Widget>[
                new IconButton(
                    icon: new Icon(
                      Icons.list,
                      color: Colors.white,
                    ),
                    onPressed: () {
                      Navigator.of(context).push(
                        new MaterialPageRoute(
                          builder: (BuildContext context) {
                            return new MyRaportClient();
                          },
                        ),
                      );
                          }),
                                      // showAlert(),
                                    ],
                                  ),new Stack(
              alignment: Alignment.topLeft,
              children: <Widget>[
                new IconButton(
                    icon: new Icon(
                      Icons.person,
                      color: Colors.white,
                    ),
                    onPressed: () {
                      Navigator.of(context).push(
                        new MaterialPageRoute(
                          builder: (BuildContext context) {
                            return new Profile();
                          },
                        ),
                      );
                          }),
                                      // showAlert(),
                                    ],
                                  )
                                ],
        ),
    body:
      Form(
              key: _formKey,
              autovalidate: _autoValidate,
      child: ListView(
        children: <Widget>[
          
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                
                children: <Widget>[
                
                  Container(
                    height: 150,
                    width: 150,
                    child: Componentss.manageImage(context, PubCon.userImage)
                         ),
                  
                ],
              ),
                     Divider(),
                  
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: nom,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.text_fields,color: Colors.grey,),
                         fillColor: Colors.red,
                         hintText: 'username',
                         labelText: 'username'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),
                    ),
                    Divider(),
                   Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                      textAlign: TextAlign.center,
                       controller: solde,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.monetization_on),
                         hintText: 'Solde',
                         labelText: 'Solde',
                          border: new OutlineInputBorder(
                       borderRadius: new BorderRadius.circular(20.0)
                   ),
                       ),
                      
                   ),),
                   Divider(),
                  Text("RECHARGER MON COMPTE",textAlign: TextAlign.center,),
                  Divider(),
                  Padding(
                    padding: const EdgeInsets.all(4.0),
                    child: Card(child: 
                    ListTile(
                      title: Text("Code Argent"),
                      leading: Icon(Icons.confirmation_number),
                    ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(4.0),
                    child: Card(child: 
                    ListTile(
                      title: Text("PayPal"),
                      leading: Icon(Icons.payment),
                    ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(4.0),
                    child: Card(child: 
                    ListTile(
                      title: Text("Carte Bancaire"),
                      leading: Icon(Icons.credit_card),
                    ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(4.0),
                    child: Card(child: 
                    ListTile(
                      title: Text("Carte Transport"),
                      leading: Icon(Icons.card_membership),
                    ),
                    ),
                  )

        ],
      ),
    )
    
    );
    
  }
}
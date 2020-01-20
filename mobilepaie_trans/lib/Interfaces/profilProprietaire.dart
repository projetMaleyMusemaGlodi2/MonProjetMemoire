import 'dart:io';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobilepaie_trans/Classes/components.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/updateProfilProprietaire.dart';

class ProfilProprietaire extends StatefulWidget {
  @override
  _ProfilProprietaireState createState() => _ProfilProprietaireState();
}

class _ProfilProprietaireState extends State<ProfilProprietaire> {
  @override
  void initState() { 
  super.initState();
  
}
//id,noms,adresse,contact,mail,typepieceid,numeropieceid,image,username,password,usersession,compte
  TextEditingController user= new TextEditingController(),
      nom = new TextEditingController(),
      adresse = new TextEditingController(),
      contact = new TextEditingController(),
      mail = new TextEditingController(),
      typepieceid = new TextEditingController(),
      numeropieceid = new TextEditingController(),
      username = new TextEditingController(),
      password = new TextEditingController();
      //compte = new TextEditingController();
      
      //=================================================================================================
      File _image;

final f=new DateFormat('yyyy-MM-dd');
DateTime date=DateTime.now();
     
bool _autoValidate = false;

  
final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  @override
  Widget build(BuildContext context) {
    username.text=PubCon.username;
    nom.text=PubCon.userNomComplet;
    adresse.text=PubCon.userAdresse;
    contact.text=PubCon.userContact;
    mail.text=PubCon.userMail;
    typepieceid.text=PubCon.userTypepieceid;
    numeropieceid.text=PubCon.userNumeropieceid;
    password.text=PubCon.password;
   
      return Scaffold(
      appBar: AppBar(centerTitle: false,
        title:new Text("Profile",style: TextStyle(color: Colors.white,fontWeight: FontWeight.bold,)),
        backgroundColor: Colors.blue,
        actions: <Widget>[
          IconButton(icon: Icon(Icons.edit),
          onPressed: (){
            //appel widget de modification--------------------
          Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => UpdateProfilProprietaire(),
                          fullscreenDialog: true));
          },
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
                    Padding(
                      padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: nom,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.supervised_user_circle,color: Colors.grey,),
                         hintText: 'Nom',
                         labelText: 'Nom*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),
                    ),
                    Padding(
                      padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: adresse,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.supervised_user_circle,color: Colors.grey,),
                         hintText: 'Adresse',
                         labelText: 'Adresse*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),
                    ),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: contact,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.text_fields,color: Colors.grey,),
                         fillColor: Colors.red,
                         hintText: 'Telephone',
                         labelText: 'Telephone*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),),
                   Padding(padding: EdgeInsets.all(2.0),
                    child: TextFormField(
                    onSaved:(value) {
                      if (value.isEmpty) {
                        return 'Entrez votre Adresse Mail';
                      }
                    },
                    obscureText: false,
                    controller: mail,
                    keyboardType: TextInputType.text,
                    style: TextStyle(fontSize: 16, color: Colors.black),
                    textInputAction: TextInputAction.next,
                    decoration: InputDecoration(
                      icon: Icon(Icons.email),
                      labelText: "Adresse Mail *",
                      contentPadding: new EdgeInsets.symmetric(
                          vertical: MediaQuery.of(context).size.height * 0.022,
                          horizontal: 15.0),
                    ),
                  ),),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: typepieceid,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.text_fields,color: Colors.grey,),
                         fillColor: Colors.red,
                         hintText: 'Type piéce Indentité',
                         labelText: 'Type piéce Indentité*'
                  
                  ),
                      
                   ),),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: numeropieceid,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.text_fields,color: Colors.grey,),
                         fillColor: Colors.red,
                         hintText: 'Numéro piéce Indentité',
                         labelText: 'Numéro piéce Indentité*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: username,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.text_fields,color: Colors.grey,),
                         fillColor: Colors.red,
                         hintText: 'Username',
                         labelText: 'Username*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),
                    ),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextFormField(
                    //focusNode: focusNode3,
                    obscureText: false,
                    enabled: false,
                    controller: password,
                    keyboardType: TextInputType.text,
                    style: TextStyle(fontSize: 16, color: Colors.black),
                    textInputAction: TextInputAction.next,
                    decoration: InputDecoration(
                      icon: Icon(Icons.lock_open),
                      labelText: "Password *",
                      contentPadding: new EdgeInsets.symmetric(
                          vertical: MediaQuery.of(context).size.height * 0.022,
                          horizontal: 15.0),
                      // border: OutlineInputBorder(
                      //   borderRadius: BorderRadius.all(Radius.circular(25)),
                      // ),
                    ),
                  ),
                      ),Divider()
                  //  RaisedButton(
                  //    child: Text("MODIFIER"),
                  //    onPressed: (){
                  //      _validateInputs(_image, context);
                  //    },
                  //  )

        ],
      ),
    )
    
    );
    
  }




}
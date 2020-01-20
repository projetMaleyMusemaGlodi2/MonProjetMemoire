import 'dart:io';
import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:intl/intl.dart';
import 'package:mobilepaie_trans/Classes/components.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:http/http.dart' as http;

class AffectationChauffeur extends StatefulWidget {
  @override
  _AffectationChauffeurState createState() => _AffectationChauffeurState();
}

class _AffectationChauffeurState extends State<AffectationChauffeur> {
  @override

   void initState() { 
   super.initState();  
   }
  //id,noms,adresse,contact,mail,typepieceid,numeropieceid,image,username,password,usersession,compte
  TextEditingController cnomsChauffeur= new TextEditingController(),
      cdetailEngin = new TextEditingController();
      //=================================================================================================
      File _image;

final f=new DateFormat('yyyy-MM-dd');
DateTime date=DateTime.now();
     
bool _autoValidate = false;

  
final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  @override
  Widget build(BuildContext context) {
    cnomsChauffeur.text=PubCon.nomsChauffeur;
    cdetailEngin.text=PubCon.detailEngin;
    
      return Scaffold(
      appBar: AppBar(centerTitle: false,
        title:new Text("Affectation Chauffeur",style: TextStyle(color: Colors.white,fontWeight: FontWeight.bold,)),
        backgroundColor: Colors.blue,
        actions: <Widget>[
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
                    child: Componentss.manageImage(context, PubCon.imageChauffeur)
                         ),
                  
                ],
              ),
                     Divider(),
                    Padding(
                      padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: cnomsChauffeur,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.supervised_user_circle,color: Colors.grey,),
                         hintText: 'Chauffeur',
                         labelText: 'Chauffeur*'
                        ),
                      
                   ),
                    ),
                    Padding(
                      padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: cdetailEngin,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.supervised_user_circle,color: Colors.grey,),
                         hintText: 'Engin',
                         labelText: 'Engin*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),
                    ),Divider(),
                  RaisedButton(
                      child: Text("VALIDER"),
                     onPressed: (){
                       saveUser(context);
                      },
                    )

        ],
      ),
    )
    
    );
    
  }

  Future saveUser(BuildContext ctx) async {
    
      try{
        var uri = Uri.parse(PubCon.cheminPhp + "insertAffectChauffeur.php");
        var request = new http.MultipartRequest("POST", uri);
            request.fields['refEngin'] = PubCon.idEngins.toString();    
            request.fields['refChauffeur'] = PubCon.idChauffeur.toString();            
            request.fields['usersession'] = PubCon.username;
            //request.files.add(multipartFile);
        var response = await request.send();
        if (response.statusCode == 200) {
          print("Enregistrement reussi");
          Fluttertoast.showToast(msg:'Affectation Enregistrée',toastLength:Toast.LENGTH_SHORT,
                                  backgroundColor:Colors.white,textColor:Colors.black);          
        } else {
          print("Echec d'enregistrement");
          Fluttertoast.showToast(msg:'Echec enregistrement',toastLength:Toast.LENGTH_SHORT,
                                  backgroundColor:Colors.white,textColor:Colors.red);
        }
        }catch(e){
          print(e);
        }

  }
}
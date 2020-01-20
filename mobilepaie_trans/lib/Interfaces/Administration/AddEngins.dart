import 'package:fluttertoast/fluttertoast.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';
import 'package:http/http.dart' as http;

class AddEngin extends StatefulWidget {
  @override
  _AddEnginState createState() => _AddEnginState();
}
//id,marque,couleur,numeroplaque,refProprietaire,refCategorie,nombreplace,compte,usersession
class _AddEnginState extends State<AddEngin> {
  TextEditingController cmarque= new TextEditingController(),
      ccouleur = new TextEditingController(),
      cnumeroplaque = new TextEditingController(),
      cnombrepalce = new TextEditingController();
      

  FocusNode focusNode1;
  FocusNode focusNode2;
  FocusNode focusNode3;
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  
  @override
  void initState() {
    super.initState();

    focusNode1 = FocusNode();
    focusNode2 = FocusNode();
    focusNode3 = FocusNode();
  }

  @override
  void dispose() {
    // Clean up the focus node when the Form is disposed
    focusNode1.dispose();
    focusNode2.dispose();
    focusNode3.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: AppBar(
        elevation: 0.0,
        title: Text("Enregistrement des Engins"),),
      
      //resizeToAvoidBottomPadding: false,
      body: ListView(
        children: <Widget>[ 
          SizedBox(
                        height: 12,
                      ),       
          Container(
            //width: MediaQuery.of(context).size.width,
            //height: (MediaQuery.of(context).size.height * 0.80) - 22,
             margin: EdgeInsets.fromLTRB(20, 12, 20, 10),
            child: 
              Form(
                  key: _formKey,
                  autovalidate: _autoValidate,
                  child: 
                  Column(
                    children: <Widget>[
                      TextFormField(
                        validator: (value) {
                          if (value.isEmpty) {
                            return 'Entrez la marque';
                          }
                        },
                        obscureText: false,
                        controller: cmarque,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Marque *",
                          contentPadding: new EdgeInsets.symmetric(
                              vertical: MediaQuery.of(context).size.height * 0.022,
                              horizontal: 15.0),
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(Radius.circular(25)),
                          ),
                        ),
                        onFieldSubmitted: (String value) {
                          FocusScope.of(context).requestFocus(focusNode1);
                        },
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      TextFormField(
                        validator: (value) {
                          if (value.isEmpty) {
                            return 'Entrez le numéro de la plaque' ;
                          }
                        },
                        obscureText: false,
                        controller: cnumeroplaque,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Numéro de la plaque *",
                          contentPadding: new EdgeInsets.symmetric(
                              vertical: MediaQuery.of(context).size.height * 0.022,
                              horizontal: 15.0),
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(Radius.circular(25)),
                          ),
                        ),
                        onFieldSubmitted: (String value) {
                          FocusScope.of(context).requestFocus(focusNode1);
                        },
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      TextFormField(
                        validator: (value) {
                          if (value.isEmpty) {
                            return 'Entrez la Couleur';
                          }
                        },
                        obscureText: false,
                        controller: ccouleur,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Couleur *",
                          contentPadding: new EdgeInsets.symmetric(
                              vertical: MediaQuery.of(context).size.height * 0.022,
                              horizontal: 15.0),
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(Radius.circular(25)),
                          ),
                        ),
                        onFieldSubmitted: (String value) {
                          FocusScope.of(context).requestFocus(focusNode1);
                        },
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      TextFormField(
                        validator: (value) {
                          if (value.isEmpty) {
                            return 'Entrez le nombre de place';
                          }
                        },
                        obscureText: false,
                        controller: cnombrepalce,
                        keyboardType: TextInputType.number,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Nombre de place  *",
                          contentPadding: new EdgeInsets.symmetric(
                              vertical: MediaQuery.of(context).size.height * 0.022,
                              horizontal: 15.0),
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(Radius.circular(25)),
                          ),
                        ),
                        onFieldSubmitted: (String value) {
                          FocusScope.of(context).requestFocus(focusNode1);
                        },
                      ),
                      SizedBox(
                        height: 10,
                      ),
                            //),  
                    
                      SizedBox(
                        height: 15,
                      ),
                      Container(
                        child: GestureDetector(
                            onTap: () {
                              print("pressed");
                              _validateInputs(context);
                            },
                            child: Container(
                              height: MediaQuery.of(context).size.height * 0.065,
                              decoration: BoxDecoration(
                                  color: Colors.blueAccent,
                                  borderRadius:
                                      BorderRadius.all(Radius.circular(25))),
                              child: Center(
                                child: Text(
                                  "Enregistrer",
                                  style:
                                      TextStyle(color: Colors.white, fontSize: 16),
                                ),
                              ),
                            )),
                      ),
                      SizedBox(
                        height: 12,
                      ),
                      SizedBox(
                        height: 12,
                      ),
                      
                    ],
                  ),
                ),
            
          )
      ],
       ),
    );
  }

 // bool _value1 = false;
  bool _autoValidate = false;
  void _validateInputs( BuildContext ctx) {
    if (_formKey.currentState.validate()) {
      //    If all data are correct then save data to out variables
      _formKey.currentState.save();
      //save user in the database
      saveUser(ctx);
    } else {
      //    If all data are not valid then start auto validation.
      setState(() {
        _autoValidate = true;
      });
    }
  }

 
//marque,couleur,numeroplaque,refProprietaire,refCategorie,nombreplace,compte,usersession
//procedure for saving user
Future saveUser(BuildContext ctx) async {
    
try{
        var uri = Uri.parse(PubCon.cheminPhp + "insertEngin.php");
        var request = new http.MultipartRequest("POST", uri);
            request.fields['marque'] = cmarque.text;    
            request.fields['couleur'] = ccouleur.text;
            request.fields['numeroplaque'] = cnumeroplaque.text;
            request.fields['refProprietaire'] = PubCon.userId.toString();
            request.fields['refCategorie'] = PubCon.idCat.toString();
            request.fields['nombreplace'] = cnombrepalce.text;
            request.fields['compte'] = 0.toString();
            request.fields['usersession'] = PubCon.username;
            //request.files.add(multipartFile);
        var response = await request.send();
        if (response.statusCode == 200) {
          print("Enregistrement reussi");
          Fluttertoast.showToast(msg:'Engin Enregistré',toastLength:Toast.LENGTH_SHORT,
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

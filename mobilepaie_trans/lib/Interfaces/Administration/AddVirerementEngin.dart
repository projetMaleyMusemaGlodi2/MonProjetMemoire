import 'package:fluttertoast/fluttertoast.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';
import 'package:http/http.dart' as http;

class AddVirementEngin extends StatefulWidget {
  @override
  _AddVirementEnginState createState() => _AddVirementEnginState();
}

class _AddVirementEnginState extends State<AddVirementEngin> {
 TextEditingController cengin= new TextEditingController(),
      caffectengin= new TextEditingController(),
      cmontant = new TextEditingController(),
      clibelle = new TextEditingController();
      

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
    cengin.text=PubCon.detailEngin;
    caffectengin.text=PubCon.detailAffectation;
        
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: AppBar(
        elevation: 0.0,
        title: Text("Retrait des Recettes"),),
      
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
                            return 'Selectionnez le Engin svp';
                          }
                        },
                        obscureText: false,
                        controller: cengin,
                        enabled: false,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Engin *",
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
                      ),TextFormField(
                        validator: (value) {
                          if (value.isEmpty) {
                            return 'Selectionnez le Engin svp';
                          }
                        },
                        obscureText: false,
                        controller: caffectengin,
                        enabled: false,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Affection Engin *",
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
                            return 'Entrez le montant' ;
                          }
                        },
                        obscureText: false,
                        controller: cmontant,
                        keyboardType: TextInputType.number,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Montant *",
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
                            return 'Entrez le libelle';
                          }
                        },
                        obscureText: false,
                        controller: clibelle,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Libellé *",
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

 
//,montant,refAffectChauffeur,refEngin,libelle,datevirement,usersession FROM `tvirement`
//procedure for saving user
Future saveUser(BuildContext ctx) async {
    
try{
        var uri = Uri.parse(PubCon.cheminPhp + "insertVirement.php");
        var request = new http.MultipartRequest("POST", uri);
            request.fields['montant'] = cmontant.text;    
            request.fields['refAffectChauffeur'] = PubCon.refAffectation.toString();
            request.fields['refEngin'] = PubCon.idEngins.toString();
            request.fields['libelle'] = clibelle.text;
            request.fields['usersession'] = PubCon.username.toString();
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
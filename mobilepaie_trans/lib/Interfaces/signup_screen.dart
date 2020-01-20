import 'dart:io';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/login_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';
import 'package:http/http.dart' as http;

class SignupScreen extends StatefulWidget {
  @override
  _SignupScreenState createState() => _SignupScreenState();
}

class _SignupScreenState extends State<SignupScreen> {

TextEditingController cnom = new TextEditingController(),
cadresse= new TextEditingController(),
      ccontact = new TextEditingController(),
      cmail = new TextEditingController(),
      ctypepieceid = new TextEditingController(),
      cnumeropieceid = new TextEditingController(),
      cusername = new TextEditingController(),
      cpassword = new TextEditingController();
DateTime date;
Future<Null> _selectDate(BuildContext context) async{
  final DateTime picked = await
  showDatePicker(
                    context: context,
                    initialDate: DateTime.now(),
                    firstDate: DateTime(1900),
                    lastDate: DateTime(2099),

                  );
                  setState(() {
                   date =picked;
                  });
}





  
  File _image;
  FocusNode focusNode1;
  FocusNode focusNode2;
  FocusNode focusNode3;
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  //String _email;
  String _password;


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
        title: Text("Création compte"),),
      
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
                            return 'Entrez votre nom';
                          }
                        },
                        obscureText: false,
                        controller: cnom,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Noms *",
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
                            return 'Entrez votre Adresse';
                          }
                        },
                        obscureText: false,
                        controller: cadresse,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Adresse *",
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
                            return 'Entrez votre Numero';
                          }
                        },
                        obscureText: false,
                        controller: ccontact,
                        keyboardType: TextInputType.phone,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Telephone *",
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
                            return 'Entrez le type de la piéce Identité';
                          }
                        },
                        obscureText: false,
                        controller: ctypepieceid,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Type piéce  *",
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
                            return 'Entrez le Numero de la piéce';
                          }
                        },
                        obscureText: false,
                        controller: cnumeropieceid,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Numéro piéce  *",
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
                            return 'Entrez votre username ';
                          }
                        },
                        obscureText: false,
                        controller: cusername,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.next,
                        decoration: InputDecoration(
                          labelText: "Username *",
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
                        validator: validatePassword,
                        onSaved: (String val) {
                          _password = val;
                        },
                        focusNode: focusNode3,
                        obscureText: true,
                        controller: cpassword,
                        keyboardType: TextInputType.text,
                        style: TextStyle(fontSize: 16, color: Colors.black),
                        textInputAction: TextInputAction.done,
                        decoration: InputDecoration(
                          labelText: "Password *",
                          contentPadding: new EdgeInsets.symmetric(
                              vertical: MediaQuery.of(context).size.height * 0.022,
                              horizontal: 15.0),
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(Radius.circular(25)),
                          ),
                        ),
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      // Padding(
                      //         padding:
                      //             const EdgeInsets.fromLTRB(0.0, 0.0, 64.0, 8.0),
                              //child: 
                              TextFormField(
                                focusNode: FocusNode(),
                                  validator: validateEmail,
                                  onSaved: (value) {
                                    if (value.isEmpty) {
                                      return 'Entrez votre Adresse Mail';
                                    }
                                  },
                                  keyboardType: TextInputType.emailAddress,
                                  controller: cmail,
                                  decoration: InputDecoration(
                                    contentPadding: new EdgeInsets.symmetric(
                              vertical: MediaQuery.of(context).size.height * 0.022,
                              horizontal: 15.0),
                                    border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(Radius.circular(25)),
                          ),
                                    labelText: "Mail",
                                  )),
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
                                  "Valider",
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

  //void _value1Changed(bool value) => setState(() => _value1 = value);

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

  String validateEmail(String value) {
    if (!value.isEmpty) {
      Pattern pattern =
          r'^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$';
      RegExp regex = new RegExp(pattern);
      if (!regex.hasMatch(value))
        return 'Enter Valid Email';
      else
        return null;
    }
  }

  String validatePassword(String value) {
    if (value.length < 4)
      return 'Password doit avoir au minimum 4 caracteres';
    else
      return null;
  }

//procedure for saving user
Future saveUser(BuildContext ctx) async {
    
    if(PubCon.typeUser=="client")
    {

    try{
        var uri = Uri.parse(PubCon.cheminPhp + "insertClient.php");
        var request = new http.MultipartRequest("POST", uri);
        //var multipartFile = new http.MultipartFile("image", stream, length,
          // filename: basename(imageFile.path));
            request.fields['noms'] = cnom.text;    
            request.fields['adresse'] = cadresse.text;
            request.fields['contact'] = ccontact.text;
            request.fields['mail'] = cmail.text;
            request.fields['typepieceid'] = ctypepieceid.text;
            request.fields['numeropieceid'] = cnumeropieceid.text;
            request.fields['username'] = cusername.text;
            request.fields['password'] = cpassword.text;
            request.fields['usersession'] = cusername.text; 
        //request.files.add(multipartFile);
        var response = await request.send();
        if (response.statusCode == 200) {
          print("Enregistrement reussi");
          Fluttertoast.showToast(msg:'Passager Enregistré',toastLength:Toast.LENGTH_SHORT,
                                  backgroundColor:Colors.white,textColor:Colors.black);
          Navigator.pushReplacement(
              ctx,
              MaterialPageRoute(
                  builder: (ctx) => LoginScreen(), fullscreenDialog: true));
        } else {
          print("Echec d'enregistrement");
          Fluttertoast.showToast(msg:'Echec enregistrement',toastLength:Toast.LENGTH_SHORT,
                                  backgroundColor:Colors.white,textColor:Colors.red);
        }
        }catch(e){
          print(e);
        }

    }
    else if(PubCon.typeUser=="proprietaire")
    {

        try{
            var uri = Uri.parse(PubCon.cheminPhp + "insertProprietaire.php");
            var request = new http.MultipartRequest("POST", uri);
            //var multipartFile = new http.MultipartFile("image", stream, length,
              // filename: basename(imageFile.path));
                request.fields['noms'] = cnom.text;    
                request.fields['adresse'] = cadresse.text;
                request.fields['contact'] = ccontact.text;
                request.fields['mail'] = cmail.text;
                request.fields['typepieceid'] = ctypepieceid.text;
                request.fields['numeropieceid'] = cnumeropieceid.text;
                request.fields['username'] = cusername.text;
                request.fields['password'] = cpassword.text;
                request.fields['usersession'] = cusername.text; 
            //request.files.add(multipartFile);
            var response = await request.send();
            if (response.statusCode == 200) {
              print("Enregistrement reussi");
              Fluttertoast.showToast(msg:'Passager Enregistré',toastLength:Toast.LENGTH_SHORT,
                                      backgroundColor:Colors.white,textColor:Colors.black);
              Navigator.pushReplacement(
                  ctx,
                  MaterialPageRoute(
                      builder: (ctx) => LoginScreen(), fullscreenDialog: true));
            } else {
              print("Echec d'enregistrement");
              Fluttertoast.showToast(msg:'Echec enregistrement',toastLength:Toast.LENGTH_SHORT,
                                      backgroundColor:Colors.white,textColor:Colors.red);
            }
            }catch(e){
              print(e);
            }

    }
    else if(PubCon.typeUser=="chauffeur")
    {

          try{
              var uri = Uri.parse(PubCon.cheminPhp + "insertChauffeur.php");
              var request = new http.MultipartRequest("POST", uri);
              //var multipartFile = new http.MultipartFile("image", stream, length,
                // filename: basename(imageFile.path));
                  request.fields['noms'] = cnom.text;    
                  request.fields['adresse'] = cadresse.text;
                  request.fields['contact'] = ccontact.text;
                  request.fields['mail'] = cmail.text;
                  request.fields['typepieceid'] = ctypepieceid.text;
                  request.fields['numeropieceid'] = cnumeropieceid.text;
                  request.fields['username'] = cusername.text;
                  request.fields['password'] = cpassword.text;
                  request.fields['usersession'] = cusername.text; 
              //request.files.add(multipartFile);
              var response = await request.send();
              if (response.statusCode == 200) {
                print("Enregistrement reussi");
                Fluttertoast.showToast(msg:'Passager Enregistré',toastLength:Toast.LENGTH_SHORT,
                                        backgroundColor:Colors.white,textColor:Colors.black);
                Navigator.pushReplacement(
                    ctx,
                    MaterialPageRoute(
                        builder: (ctx) => LoginScreen(), fullscreenDialog: true));
              } else {
                print("Echec d'enregistrement");
                Fluttertoast.showToast(msg:'Echec enregistrement',toastLength:Toast.LENGTH_SHORT,
                                        backgroundColor:Colors.white,textColor:Colors.red);
              }
              }catch(e){
                print(e);
              }

    }else{}


  }

}

class RoundedClipper extends CustomClipper<Path> {
  var differenceInHeights = 0;

  RoundedClipper(int differenceInHeights) {
    this.differenceInHeights = differenceInHeights;
  }

  @override
  Path getClip(Size size) {
    var path = Path();
    path.lineTo(0, size.height - differenceInHeights);
    path.quadraticBezierTo(
        size.width / 2, size.height, size.width, size.height);
    path.lineTo(size.width, 0);
    path.close();
    return path;
  }

  @override
  bool shouldReclip(CustomClipper<Path> oldClipper) => false;
}

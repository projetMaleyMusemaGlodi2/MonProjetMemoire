//import 'dart:io';
import 'dart:async';
import 'dart:convert';


import 'package:fluttertoast/fluttertoast.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:carousel_pro/carousel_pro.dart';
import 'package:mobilepaie_trans/Classes/clsAlert.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/alertes.dart';
import 'package:mobilepaie_trans/Interfaces/login_screen.dart';
import 'package:mobilepaie_trans/SharedPref/myPreferences.dart';
import 'package:mobilepaie_trans/main.dart';
import 'package:shared_preferences/shared_preferences.dart';

class MyHomePageScreen extends StatefulWidget {
  @override
  HomeScreen createState() => HomeScreen();
}

class HomeScreen extends State<MyHomePageScreen> {
  MyPreferences _myPreferences = MyPreferences();
  void conditionProfil(String menu) {
    //test si connected pour voir profil
    if (PubCon.userId != '-1' &&
        PubCon.userId != 'null' &&
        PubCon.userId != null) {
      if (menu == 'profile') {
        Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => MyApp(),
            ));
      } else if (menu == 'monCompte') {
        Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => MyApp(),
            ));
      }
    } else {
      Navigator.push(
          context, MaterialPageRoute(builder: (context) => LoginScreen()));
    }
    //sinon envoi un message et dirige sur login
  }
Future<bool> saveNombreAlertPref(int nombre) async{
SharedPreferences pref=await SharedPreferences.getInstance();
pref.setInt("nombre", nombre);
return pref.commit();
}
Future<int> getNombreAlertPref() async{
  SharedPreferences pref=await SharedPreferences.getInstance();
  int nombre =pref.getInt("nombre");

return nombre;
}
  int nombreAlertPref=0;
  int totAlert = 0;
  Future<List> _chargerAlert() async {
    try{
    final response =
        await http.post(PubCon.cheminPhp + "GetAlerteAgence.php", body: {});
    var datauser = json.decode(response.body);
    if(mounted){
    setState(() {
      
      if (((datauser.length==null? 0 : datauser.length) - (nombreAlertPref==null ? 0 : nombreAlertPref)) < 0) {
        Alert.newAlert = 0;
      } else {
        Alert.newAlert = (datauser.length==null? 0 : datauser.length) - (nombreAlertPref==null ? 0 : nombreAlertPref);
      }
      totAlert = (datauser.length==null? 0 : datauser.length);
    });}
    return datauser;
    }catch(e){

    }
  }

  @override
  void initState() {
    super.initState();
getNombreAlertPref().then(updateNombre);

    _chargerAlert();



    // _myPreferences.init().then((value) {
    //   if (mounted)
    //     setState(() {
    //       _myPreferences = value;
    //     });
    // });
  }

  Widget showAlert() {
    if (Alert.newAlert > 0) {
      return new CircleAvatar(
        radius: 8.0,
        backgroundColor: Colors.white,
        child: new Text(
          Alert.newAlert.toString(),
          style: new TextStyle(color: Colors.red, fontSize: 12.0),
        ),
      );
    } else {
      return Text("");
    }
  }

  @override
  Widget build(BuildContext context) {
    //initialisation par les donnees en memoire
//     PubCon.userId=_myPreferences.iduser==""? '-1' :_myPreferences.iduser;
//     PubCon.userName=_myPreferences.user==""? 'sTicket' : _myPreferences.user;
// PubCon.userNomComplet=_myPreferences.nomcomplet==""?'Smart Ticket':_myPreferences.nomcomplet;
// PubCon.userPass=_myPreferences.password;
// PubCon.userPrivilege=_myPreferences.privilege==""?'0': _myPreferences.privilege;
// PubCon.userImage=_myPreferences.image==""?"":_myPreferences.image;
    return new Scaffold(
        backgroundColor: Colors.white,
        resizeToAvoidBottomPadding: false,
        appBar: new AppBar(
          title: GestureDetector(
            child: new Text("TAP & LEAVE"),
          ),
          backgroundColor: Colors.blue,
          centerTitle: true,
          actions: <Widget>[
            new Stack(
              alignment: Alignment.topLeft,
              children: <Widget>[
                new IconButton(
                    icon: new Icon(
                      Icons.chat,
                      color: Colors.white,
                    ),
                    onPressed: () {
                      Navigator.of(context).push(
                        new MaterialPageRoute(
                          builder: (BuildContext context) {
                            return new MyAlert();
                          },
                        ),
                      );
                      setState(() {
                        Alert.newAlert = 0;
                        // _myPreferences.alert = totAlert;
                        // _myPreferences.commit();
                        
                      });
                      saveNombre();
                                          }),
                                      showAlert(),
                                    ],
                                  )
                                ],
                              ),
                              body: ListView(
                                children: <Widget>[
                                  Stack(
                                    children: <Widget>[
                                      Column(
                                        crossAxisAlignment: CrossAxisAlignment.center,
                                        children: <Widget>[
                                          //SizedBox(height: 100),
                                          Container(
                                            height: MediaQuery.of(context).size.height * 0.60,
                                            child: buildGrid(context),
                                          ),
                                          SizedBox(
                                            height: 10,
                                          ),
                                          Container(
                                            decoration: BoxDecoration(
                                                borderRadius: BorderRadius.circular(10),
                                                gradient: LinearGradient(
                                                    begin: Alignment.topLeft,
                                                    end: Alignment.bottomRight,
                                                    colors: [
                                                      Colors.blue[600],
                                                      Colors.blue[500],
                                                      Colors.blue,
                                                      Colors.blue[400],
                                                      Colors.blue[300]
                                                    ])),
                                            margin: EdgeInsets.only(left: 12, right: 12),
                                          ),
                                          Container(
                                            margin: EdgeInsets.only(left: 12, right: 12),
                                            child: SizedBox(
                                              height: 120,
                                              child: ImageCarousel(),
                                            ),
                                          ),
                                        ],
                                      )
                                    ],
                                  )
                                ],
                              ));
                        }
                      
                        Widget buildGrid(BuildContext context) {
                          return GridView.count(
                            padding: EdgeInsets.fromLTRB(0, 5, 0, 5),
                            crossAxisCount: 2,
                            shrinkWrap: true,
                            childAspectRatio: (MediaQuery.of(context).size.width - 60 / 3) / 300,
                            children: <Widget>[
                              buildTile(context, 0, "Passagers", null, Icons.people, "O items",
                                  Colors.orange, Colors.deepPurple[50]),
                              buildTile(context, 1, "Propriétaires", null, Icons.person_pin, "0 items",
                                  Colors.blue, Colors.blue[50]),
                              buildTile(context, 2, "Chauffeurs", null, Icons.directions_transit, "0 items",
                                  Colors.purple, Colors.purple[50]),
                              buildTile(context, 3, "Agents", null, Icons.nature_people, "0 items",
                                  Colors.red, Colors.blueGrey[50]),
                            ],
                          );
                        }
                      
                        int _selectedIndex = -1;
                      
                        Widget buildTile(BuildContext context, int index, String heading, Image image,
                            IconData icon, String itemCount, Color color, Color backgroundColor) {
                          return Container(
                            padding: EdgeInsets.only(
                                left: index == 0 || index == 2 || index == 4 ? 12 : 5,
                                top: 0,
                                right: index == 1 || index == 3 || index == 5 ? 12 : 5,
                                bottom: 10),
                            decoration: BoxDecoration(
                                color: Colors.white, borderRadius: BorderRadius.circular(10)),
                            child: GestureDetector(
                              onTap: () {
                                setState(() {
                                  _selectedIndex = index;
                                  if (_selectedIndex == 0) {                                    
                                    PubCon.typeUser="client";
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => LoginScreen()));                                        
                                  } else if (_selectedIndex == 1) {                                   
                                    PubCon.typeUser="proprietaire";
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => LoginScreen()));                                        
                                  } else if (_selectedIndex == 2) {
                                    PubCon.typeUser="chauffeur";
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => LoginScreen()));                                        
                                  } else if (_selectedIndex == 3) {
                                    PubCon.typeUser="agent";
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => LoginScreen()));
                                  }
                                });
                                print("tapped");
                              },
                              child: Card(
                                  elevation: 3,
                                  shape: RoundedRectangleBorder(
                                      side: BorderSide(
                                          width: 1.0,
                                          style: BorderStyle.solid,
                                          color: _selectedIndex == index && color != null
                                              ? color
                                              : Colors.white),
                                      borderRadius: BorderRadius.circular(10)),
                                  color: Colors.white,
                                  child: Center(
                                      child: Column(
                                    mainAxisAlignment: MainAxisAlignment.center,
                                    crossAxisAlignment: CrossAxisAlignment.center,
                                    children: <Widget>[
                                      Stack(
                                        alignment: Alignment(0, 0),
                                        children: <Widget>[
                                          Container(
                                            width: 43,
                                            height: 43,
                                            decoration: BoxDecoration(
                                                color: backgroundColor,
                                                borderRadius: BorderRadius.circular(15)),
                                          ),
                                          index == 4
                                              ? IconButton(
                                                  icon: image,
                                                  onPressed: () {},
                                                )
                                              : Icon(
                                                  icon,
                                                  color: color,
                                                  size: 30.0,
                                                ),
                                          index != 1
                                              ? SizedBox(
                                                  height: 4,
                                                )
                                              : SizedBox(
                                                  height: 0,
                                                ),
                                        ],
                                      ),
                                      Text(
                                        heading,
                                        style: TextStyle(
                                            color: Colors.black,
                                            fontSize: 18,
                                            fontWeight: FontWeight.w600),
                                      ),
                                      SizedBox(
                                        height: 4,
                                      ),
                                      Text(
                                        itemCount,
                                        style: TextStyle(
                                            color: Colors.grey,
                                            fontSize: 12,
                                            fontWeight: FontWeight.w300),
                                      )
                                    ],
                                  ))),
                            ),
                      //      ),
                          );
                        }
                      
                        void saveNombre() {
                          int nombre=totAlert;
                          saveNombreAlertPref(nombre).then((bool committed){
                            Fluttertoast.showToast(
                      msg: '$nombre new Alert(s) reçue(s)',
                      toastLength: Toast.LENGTH_SHORT,
                      backgroundColor: Colors.white,
                      textColor: Colors.black);
                          });
                        }

  void updateNombre(int nombre) {
setState(() {
 this.nombreAlertPref=nombre; 
});
  }


  
}

class ImageCarousel extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return GridView.count(
      padding: EdgeInsets.fromLTRB(0, 5, 0, 5),
      crossAxisCount: 2,
      shrinkWrap: true,
      //childAspectRatio: (MediaQuery.of(context).size.width - 60 / 3) / 300,
      children: <Widget>[
        Padding(
          padding: const EdgeInsets.only(right: 6.0),
          child: Container(
            decoration: BoxDecoration(
                color: Colors.white, borderRadius: BorderRadius.circular(20)),
            child: Carousel(
                boxFit: BoxFit.fill,
                images: [
                  AssetImage('assets/images/1.png'),
                  AssetImage('assets/images/4.png'),
                  AssetImage('assets/images/5.png'),
                ],
                animationCurve: Curves.fastLinearToSlowEaseIn,
                animationDuration: Duration(milliseconds: 3000)),
          ),
        ),
        Padding(
          padding: const EdgeInsets.only(left: 6.0),
          child: Container(
            decoration: BoxDecoration(
                color: Colors.white, borderRadius: BorderRadius.circular(20)),
            child: Carousel(
                boxFit: BoxFit.fill,
                images: [
                  AssetImage('assets/images/5.png'),
                  AssetImage('assets/images/1.png'),
                  AssetImage('assets/images/4.png'),
                ],
                animationCurve: Curves.linearToEaseOut,
                animationDuration: Duration(milliseconds: 2000)),
          ),
        )
      ],
    );
  }
}

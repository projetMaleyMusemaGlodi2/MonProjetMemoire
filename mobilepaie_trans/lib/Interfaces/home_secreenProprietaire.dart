import 'package:flutter/services.dart';

import 'package:flutter/material.dart';
//import 'package:flutter/src/material/icon_button.dart';
import 'package:mobilepaie_trans/Classes/components.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/ListeEngins.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/SearchCategorieEngin.dart';
import 'package:mobilepaie_trans/Interfaces/aide.dart';
import 'package:mobilepaie_trans/Interfaces/alertes.dart';
import 'package:mobilepaie_trans/Interfaces/home_screen.dart';
import 'package:mobilepaie_trans/Interfaces/login_screen.dart';
import 'package:mobilepaie_trans/Interfaces/mesEngins.dart';
import 'package:mobilepaie_trans/Interfaces/nosEngins.dart';
import 'package:mobilepaie_trans/Interfaces/profilProprietaire.dart';

class HomeProprietaire extends StatefulWidget {
  @override
  _HomeProprietaireState createState() => _HomeProprietaireState();
}

class _HomeProprietaireState extends State<HomeProprietaire> {
  @override
  void initState() {
    super.initState();

  }
  Widget build(BuildContext context) {
    
    return new Scaffold(
        backgroundColor: Colors.white,
        resizeToAvoidBottomPadding: false,
        appBar: new AppBar(
          title: GestureDetector(
            child: new Text("TAP & LEAVE"),
          ),
          backgroundColor: Colors.blue,
          centerTitle: true,
                              ) ,
                              drawer: new Drawer(
                                child: new ListView(
                                  children: <Widget>[
                                    new UserAccountsDrawerHeader(
                                      accountName: new Text('${PubCon.username}'),
                                      accountEmail: new Text('${PubCon.userNomComplet}'),
                                      currentAccountPicture: new GestureDetector(
                                          onTap: () {
                                            Navigator.push(
                                            context,
                                            MaterialPageRoute(
                                              builder: (context) => MyHomePageScreen(),
                                            ));
                                          },
                                          child: Componentss.manageImage(context, PubCon.userImage)
                                          
                                          ),
                                      decoration: new BoxDecoration(
                                        color: Colors.blue,
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        Navigator.of(context).pop();
                                      },
                                      child: new ListTile(
                                        title: new Text('Acceuil',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(Icons.home,color: Colors.lightBlue),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        Navigator.of(context).push(
                                          new MaterialPageRoute(
                                            builder: (BuildContext context) {
                                              return new ProfilProprietaire();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Profil',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.person,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        Navigator.push(
                                          context,
                                          MaterialPageRoute(
                                            builder: (context) {
                                              return NosEngins();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Mon compte',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.attach_money,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        Navigator.push(
                                          context,
                                          MaterialPageRoute(
                                            builder: (context) {
                                              return ListeCategorieEngin();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Ajouter un Engins',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.directions_bus,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        PubCon.typeopProprietaire="affect";
                                          Navigator.of(context).push(
                                          new MaterialPageRoute(
                                            builder: (BuildContext context) {
                                              return new MesEngins();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Affectation des Chauffeurs',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.accessible,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        PubCon.typeopProprietaire="rapport";
                                          Navigator.of(context).push(
                                          new MaterialPageRoute(
                                            builder: (BuildContext context) {
                                              return new MesEngins();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Rapports de mes engins',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.list,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        Navigator.of(context).push(
                                          new MaterialPageRoute(
                                            builder: (BuildContext context) {
                                              return new MyAlert();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Alerts',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.alarm,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        Navigator.pushReplacement(
                                              context,
                                              MaterialPageRoute(
                                                  builder: (context) => LoginScreen(),
                                                  fullscreenDialog: true));
                      //Accueil Administration
                                      },
                                      child: new ListTile(
                                        title: new Text(
                                          'Connexion',
                                          style: new TextStyle(color: Colors.blue),
                                        ),
                                        leading: new Icon(
                                          Icons.lock_open,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        Navigator.of(context).push(
                                          new MaterialPageRoute(
                                            builder: (BuildContext context) {
                                              return new AideUser();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text(
                                          'Aide',
                                          style: new TextStyle(color: Colors.blue),
                                        ),
                                        leading: new Icon(
                                          Icons.help,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        SystemChannels.platform.invokeMethod('SystemNavigator.pop');
                                      },
                                      // {
                                      //   // MyPreferences _myPreferences=MyPreferences();
                                      //   // _myPreferences.automatic=false;
                      
                                      //   Navigator.pop(context);
                                      // },
                                      child: new ListTile(
                                        title: new Text(
                                          'Quitter',
                                          style: new TextStyle(color: Colors.red),
                                        ),
                                        leading: new Icon(
                                          Icons.close,
                                          color: Colors.red,
                                        ),
                                      ),
                                    ),
                                    Divider(),
                                  ],
                                ),
                              )   ,
                              body: Container(
                                            decoration: BoxDecoration(
                                              image: DecorationImage(
                                                image: AssetImage('assets/images/5.png'),
                                                fit: BoxFit.fill
                                              )
                                            ),
                                            height: MediaQuery.of(context).size.height
                                          ));
  }
}
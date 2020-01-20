import 'package:flutter/services.dart';

import 'package:flutter/material.dart';
//import 'package:flutter/src/material/icon_button.dart';
import 'package:mobilepaie_trans/Classes/components.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/ChargerCompteclient.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/ListeEnginSeachVirement.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/ListeEngins.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/ParametrePrix.dart';
import 'package:mobilepaie_trans/Interfaces/Administration/rapportEngin.dart';
import 'package:mobilepaie_trans/Interfaces/aide.dart';
import 'package:mobilepaie_trans/Interfaces/alertes.dart';
import 'package:mobilepaie_trans/Interfaces/description.dart';
import 'package:mobilepaie_trans/Interfaces/home_screen.dart';
import 'package:mobilepaie_trans/Interfaces/login_screen.dart';


class HomeAdmin extends StatefulWidget {
  @override
  _HomeAdminState createState() => _HomeAdminState();
}

class _HomeAdminState extends State<HomeAdmin> {

  @override
  void initState() {
    super.initState();

  }

  @override
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
                                              return new MyReport();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Rapports',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.list,
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
                                              return ParametrePrix();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Voir Prix de Transport',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.settings,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        PubCon.typeopAdmin='paiement';
                                        Navigator.of(context).push(
                                          new MaterialPageRoute(
                                            builder: (BuildContext context) {
                                              return new ListeEngins();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Paiements Transports',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.attach_money,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {},
                                      child: new ListTile(
                                        onTap: () {
                                           PubCon.typeopAdmin='recharge';
                                           Navigator.push(context,
                                           MaterialPageRoute(builder: (context) => ChargeCompteClient()
                                           ));
                                        },
                                        title: new Text('Chargements des Comptes des Clients',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.account_balance,
                                          color: Colors.lightBlue,
                                        ),
                                      ),
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        Navigator.push(context,
                                               MaterialPageRoute(builder: (context) {
                                             return ListeEnginSearchVirement();
                                          }));
                                      },
                                      child: new ListTile(
                                        title: new Text('Virement des Comptes des Engins ',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.money_off,
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
                                    new Divider(
                                      color: Colors.red,
                                      height: 4.0,
                                    ),
                                    new InkWell(
                                      onTap: () {
                                        Navigator.push(
                                          context,
                                          MaterialPageRoute(
                                            builder: (context) {
                                              return DescriptionEse();
                                            },
                                          ),
                                        );
                                      },
                                      child: new ListTile(
                                        title: new Text('Description TAP&LEAVE',
                                            style: new TextStyle(color: Colors.blue)),
                                        leading: new Icon(
                                          Icons.info,
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
                              body: 
                              ListView(
                                children: <Widget>[
                                  Stack(
                                    children: <Widget>[
                                      Column(
                                        crossAxisAlignment: CrossAxisAlignment.center,
                                        children: <Widget>[
                                            Container(
                                            height: MediaQuery.of(context).size.height,
                                            child: buildGrid(context),
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
                              buildTile(context, 0, "Paramétre", null, Icons.settings, "Prix",
                                  Colors.orange, Colors.blue[50]),
                              buildTile(context, 1, "Paiements", null, Icons.scanner,"Scanner",
                                  Colors.blue, Colors.blue[50]),
                              buildTile(context, 2, "Recharges", null, Icons.account_balance, "Compte clients",
                                  Colors.purple, Colors.blue[50]),
                              buildTile(context, 3, "Virement", null, Icons.departure_board, "Compte engins",
                                  Colors.blueAccent, Colors.blue[50]),
                              buildTile(context, 4, "Retrait", null, Icons.money_off, "Compte engins",
                                  Colors.blueGrey, Colors.blue[50]),
                              buildTile(context, 5, "Rapports", null, Icons.list, "Courses",
                                  Colors.lightBlueAccent, Colors.blue[50]),
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
                                    PubCon.typeopAdmin='prix';
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => ParametrePrix()));
                                  } else if (_selectedIndex == 1) {
                                    PubCon.typeopAdmin='paiement';
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => ListeEngins()));
                                  } else if (_selectedIndex == 2) {
                                    PubCon.typeopAdmin='recharge';
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => ChargeCompteClient()));
                                  } else if (_selectedIndex == 3) {
                                    PubCon.typeopAdmin='virement';
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => ListeEnginSearchVirement()));
                                  }
                                   else if (_selectedIndex == 4) {
                                    PubCon.typeopAdmin='retrait';
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => ListeEngins()));
                                  }
                                   else if (_selectedIndex == 5) {
                                    PubCon.typeopAdmin='rapport';
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) => MyReport()));
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
                                                  icon: Icon(Icons.ac_unit),
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
                                  )))     ,
                            ),
                      //      ),
                          );
                        }
                      

}
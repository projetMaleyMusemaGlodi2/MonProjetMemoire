import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:mobilepaie_trans/Classes/components.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:qr_flutter/qr_flutter.dart';
import 'package:qrcode_reader/qrcode_reader.dart';
import 'package:http/http.dart' as http;

class ChargeCompteClient extends StatefulWidget {
  @override
  _ChargeCompteClientState createState() => _ChargeCompteClientState();
}

//String snapCapture="";
Future saveUser(BuildContext ctx, int refClient,double montant) async {
       try{        
        var uri = Uri.parse(PubCon.cheminPhp + "insertChargecompteClient.php");
        var request = new http.MultipartRequest("POST", uri);
            request.fields['refClient'] = refClient.toString();    
            request.fields['montant'] = montant.toString();
            request.fields['usersession'] = PubCon.username;
                    //request.files.add(multipartFile);
        var response = await request.send();
        if (response.statusCode == 200) {
          print("Enregistrement reussi");
          Fluttertoast.showToast(msg:'Paiment Enregistré',toastLength:Toast.LENGTH_SHORT,
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

class _ChargeCompteClientState extends State<ChargeCompteClient> {
 int diff;
 String imageClient;
  TextEditingController cid= new TextEditingController(),
      cnoms= new TextEditingController(),
      cadresse = new TextEditingController(),
      ccontact = new TextEditingController(),
      cmail = new TextEditingController(),
      ctypepieceid = new TextEditingController(),
      cnumeropieceid = new TextEditingController(),
      cusername = new TextEditingController(),
      cpassword = new TextEditingController(),
      ccompte = new TextEditingController(),
      cmontant = new TextEditingController();
  int resQr;
  Widget identite() {
    return Column(
      children: <Widget>[
        Padding(
          padding: const EdgeInsets.all(4.0),
          child: Card(
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Column(
                children: <Widget>[
                  TextField(
                      enabled: false,
                      controller: cid,
                      decoration: InputDecoration(labelText: "ID"),
                    ),TextField(
                      enabled: false,
                      controller: cnoms,
                      decoration: InputDecoration(labelText: "Noms"),
                    ),
                    TextField(
                      enabled: false,
                      controller: cadresse,
                      decoration: InputDecoration(labelText: "Adresse"),
                    ),TextField(
                            enabled: false,
                            controller: ctypepieceid,
                            decoration: InputDecoration(labelText: "Type pièce Identité"),
                    ),TextField(
                        enabled: false,
                        controller: cmail,
                        decoration: InputDecoration(labelText: "E-mail"),
                    ),TextField(
                            enabled: false,
                            controller: ccontact,
                            decoration: InputDecoration(labelText: "Contact"),
                          ),
                    TextField(
                      enabled: false,
                      controller: cnumeropieceid,
                      decoration: InputDecoration(labelText: "Numéro pièce Identité"),
                    ),
                  
                ],
              ),
            ),
          ),
        ),
        Padding(
          padding: const EdgeInsets.all(4.0),
          child: Card(
              elevation: 2.0,
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: Column(
                  children: <Widget>[
                    TextField(
                    enabled: false,
                    controller: ccompte,
                    decoration: InputDecoration(labelText: "Compte"),
                  ),TextField(
                    enabled: true,
                    keyboardType: TextInputType.number,
                    controller: cmontant,
                    decoration: InputDecoration(labelText: "Montant*"),
                  ),
                            //),  
                    
                      SizedBox(
                        height: 15,
                      ),
                      Container(
                        child: GestureDetector(
                            onTap: () {
                              print("pressed");
                              saveUser(context,int.parse(cid.text),double.parse(cmontant.text));
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
              )),
        )
      ],
    );
  }
//noms,adresse,contact,mail,typepieceid,numeropieceid
  Future<List> _charger(String qr) async {
    final response = await http.post(PubCon.cheminPhp + "GetClientsById.php",
        body: {"id": qr});
    //print(response.body);
    var datauser = json.decode(response.body);
    if (datauser.length == 0) {
      setState(() {
        diff = null;
      });
    } else {
      if (mounted)
        setState(() {
          for (int h = 0; h < datauser.length; h++) {
            diff=int.parse(datauser[h]['id'].toString());
            cid.text=datauser[h]['id'].toString();
            cnoms.text=datauser[h]['noms'].toString();
            cadresse.text=datauser[h]['adresse'].toString();
            ccontact.text=datauser[h]['contact'].toString();
            cmail.text=datauser[h]['mail'].toString();
            ctypepieceid.text=datauser[h]['typepieceid'].toString();
            cnumeropieceid.text=datauser[h]['typepieceid'].toString();
            ccompte.text=datauser[h]['compte'].toString();
            imageClient=datauser[h]['image'].toString();            
          }
        });
    }
    return datauser;
  }

  Future<String> _codeString;

 Widget getTest(int _diff) {
    if (_diff == null) {
      return new Align(
  
                          alignment: Alignment.center,
  
                          child: Text("...En attente du scan..."));
    } else {
      if (_diff >= 0) {
        return Column(
          children: <Widget>[
            Divider(),
            ListTile(
              title: Text(
                "Client Actif",
                textAlign: TextAlign.justify,
              ),
              leading: Icon(
                Icons.verified_user,
                color: Colors.blue,
              ),
            ),
            Divider(),
            QrImage(
              data: "Client Actif",
              foregroundColor: Colors.blue,
              size: 100.0,
            ),Container(
                    height: 150,
                    width: 150,
                    child: Componentss.manageImage(context, imageClient)
                         ),
            Divider(),
            identite(),
          ],
        );
      } else {
        return Column(
          children: <Widget>[
            Divider(),
            ListTile(
              title: Text(
                "Client Inactif",
                textAlign: TextAlign.justify,
              ),
              leading: Icon(
                Icons.cancel,
                color: Colors.red,
              ),
            ),
            Divider(),
            QrImage(
              data: "Invalide",
              foregroundColor: Colors.red,
              size: 100.0,
            ),
            Divider(),
            identite()
          ],
        );
      }
    }
  }
  @override
  Widget build(BuildContext context) {
    
    return Scaffold(
      appBar: AppBar(
        title: Text('Recharge Compte'),
      ),
      body: Center(
        child: ListView(
          //mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            new FutureBuilder<String>(
              future: _codeString,
              builder: (BuildContext context, AsyncSnapshot<String> snapshot) {
                if (snapshot.data == null) {
                } else {
                  _charger(snapshot.data);
                }
                return Text(
                    snapshot.data != null ? '' : 'Scanner la Carte...');
              },
            ),
            //Text("$diff"),
            getTest(diff)
          ],
        ),
      ),
      floatingActionButton: new FloatingActionButton(
        onPressed: scannerQR,
        tooltip: 'Scanner',
        child: Icon(Icons.scanner),
      ),
    );
  }

  void scannerQR() {
    try {
      setState(() {
        _codeString = new QRCodeReader()
            .setAutoFocusIntervalInMs(200)
            .setForceAutoFocus(true)
            .setTorchEnabled(true)
            .setHandlePermissions(true)
            .setExecuteAfterPermissionGranted(true)
            .scan();
      });
    } catch (e) {}
  }
}
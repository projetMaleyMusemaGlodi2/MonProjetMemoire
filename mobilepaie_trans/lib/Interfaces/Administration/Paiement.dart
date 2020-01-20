import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:mobilepaie_trans/Classes/components.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:qr_flutter/qr_flutter.dart';
import 'package:qrcode_reader/qrcode_reader.dart';
import 'package:http/http.dart' as http;

class QRscanner extends StatefulWidget {
  @override
  _QRscannerState createState() => _QRscannerState();
}

class _QRscannerState extends State<QRscanner> {
  int diff;
  String compteClient='';  
  int resQr;
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
      ccompte = new TextEditingController();
     
       Widget identite(String qr) {
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
                  ),
                            //),  
                    
                      SizedBox(
                        height: 15,
                      ),
                      Container(
                        child: GestureDetector(
                            onTap: () {
                              print("pressed");
                            //_getCompteClient(qr);
                            if(int.parse(ccompte.text)>=int.parse(PubCon.prixTrans))
                            {
                              saveUser(context,int.parse(qr));
                            }else
                            {
                                print("Votre Compte ne suffit pas pour faire cette course, Veillez recharger votre compte svp !!!");
                                Fluttertoast.showToast(msg:'Votre Compte ne suffit pas pour faire course, Veillez recharger votre compte svp !!!',toastLength:Toast.LENGTH_SHORT,
                                            backgroundColor:Colors.red,textColor:Colors.white);                              
                            }
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
            cid.text=datauser[h]['id'].toString();
            cnoms.text=datauser[h]['noms'].toString();
            cadresse.text=datauser[h]['adresse'].toString();
            ccontact.text=datauser[h]['contact'].toString();
            cmail.text=datauser[h]['mail'].toString();
            ctypepieceid.text=datauser[h]['typepieceid'].toString();
            cnumeropieceid.text=datauser[h]['typepieceid'].toString();
            ccompte.text=datauser[h]['compte'].toString();
            imageClient=datauser[h]['image'].toString();
             diff=(int.parse(ccompte.text)-int.parse(PubCon.prixTrans));
          }
        });
    }
    return datauser;
  }
  
Future saveUser(BuildContext ctx, int refClient) async {
    _getCompteClient(refClient.toString());
    try{        
        var uri = Uri.parse(PubCon.cheminPhp + "insertPaiement.php");
        var request = new http.MultipartRequest("POST", uri);
            request.fields['montant'] = PubCon.prixTrans.toString();    
            request.fields['refClient'] = cid.text.toString();
            request.fields['refAffectChauffeur'] = PubCon.refAffectation.toString();
            request.fields['usersession'] = PubCon.username;
                    //request.files.add(multipartFile);
        var response = await request.send();
        if (response.statusCode == 200) {
          print("Enregistrement reussi");
          Fluttertoast.showToast(msg:'Paiment Enregistré'+''+compteClient,toastLength:Toast.LENGTH_SHORT,
                                  backgroundColor:Colors.white,textColor:Colors.black); 
                                  //valueQr='';         
        } else {
          print("Echec d'enregistrement");
          Fluttertoast.showToast(msg:'Echec enregistrement',toastLength:Toast.LENGTH_SHORT,
                                  backgroundColor:Colors.white,textColor:Colors.red);
                                  //Navigator.pop(ctx);
        }
        }catch(e){
          print(e);
        }
  
}


Future<List> _getCompteClient(String qr) async {
    final response = await http.post(PubCon.cheminPhp + "GetmountCompteClient.php",
        body: {"id": qr});    
    var datauser = json.decode(response.body);
    if (datauser.length == 0) {
      setState(() {
        compteClient ='0'; 
      });      
    } else {      
      setState(() {
        compteClient =datauser[0]['compte'].toString(); 
      });
          
    }
    return datauser;
  }

  Future<String> _codeString;
  Widget getTest(int _diff,String qr) {
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
                "Compte Suffisant",
                textAlign: TextAlign.justify,
              ),
              leading: Icon(
                Icons.verified_user,
                color: Colors.blue,
              ),
            ),
            Divider(),
            QrImage(
              data: "Suffisant",
              foregroundColor: Colors.blue,
              size: 100.0,
            ),Container(
                    height: 150,
                    width: 150,
                    child: Componentss.manageImage(context, imageClient)
                         ),
            Divider(),
            identite(qr),
          ],
        );
      } else {
        return Column(
          children: <Widget>[
            Divider(),
            ListTile(
              title: Text(
                "Compte Insuffisant",
                textAlign: TextAlign.justify,
              ),
              leading: Icon(
                Icons.cancel,
                color: Colors.red,
              ),
            ),
            Divider(),
            QrImage(
              data: "Insuffisant",
              foregroundColor: Colors.red,
              size: 100.0,
            ),Container(
                    height: 150,
                    width: 150,
                    child: Componentss.manageImage(context, imageClient)
                         ),
            Divider(),
            identite(qr)
          ],
        );
      }
    }
  }

  @override
  Widget build(BuildContext context) {
      return Scaffold(
      appBar: AppBar(
        title: Text('Paiement Transport'),
      ),
      body: Center(
        child: ListView(
          //mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            new FutureBuilder<String>(
              future: _codeString,
              builder: (BuildContext context, AsyncSnapshot<String> snapshot) {
                if (snapshot.data == null || snapshot.data=='') 
                {
                  // Fluttertoast.showToast(msg:'Compte non Enregistré',toastLength:Toast.LENGTH_SHORT,
                  //                 backgroundColor:Colors.white,textColor:Colors.black);
                } 
                else 
                {
                      _charger(snapshot.data);
                }
                return Text(
                    snapshot.data != null ? '' : 'Scanner la Carte...');
              },
            ),
            getTest(diff,cid.text),
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

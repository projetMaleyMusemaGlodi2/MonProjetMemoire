import 'dart:convert';
import 'package:intl/intl.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';
import 'package:http/http.dart' as http;

class MyReportProprietaire extends StatefulWidget {
  final String idEngin, idClasse, menuTrie;

  const MyReportProprietaire({Key key, this.idEngin, this.idClasse, this.menuTrie})
      : super(key: key);
  @override
  _MyReportProprietaireState createState() => _MyReportProprietaireState();
}

class _MyReportProprietaireState extends State<MyReportProprietaire> {
  TextEditingController cMontantTotal = new TextEditingController();
   @override
  void initState() {
    super.initState();
  }

  var _detailengin = [""];
  var _nom = [""];
  var _prix = [""];
  var _datepaiement = [""];
  double montantTot = 0.0;
  Future<List> _getMontantTot1() async {
    try {
      final response = await http.post(
          PubCon.cheminPhp + "GetRapportEnginbyProprietaire.php",
          body: {
                "date1": "${f.format(date1)}",
                "date2": "${f.format(date2)}",
                "refEngin": "${PubCon.idEngins.toString()}",
                "refProprietaire": "${PubCon.userId.toString()}",
               });
      print(response.body);
      var datauser = json.decode(response.body);
      if (datauser.length == 0) {
        _nom = ["Aucune reservation trouvée"];
      } else {
        _detailengin.clear();
        _nom.clear();
        _datepaiement.clear();
        _prix.clear();
        montantTot = 0.0;
        setState(() {
          for (int h = 0; h < datauser.length; h++) {
            _detailengin.add(datauser[h]['detailEngin'].toString());
            _nom.add(datauser[h]['Client'].toString());
            _datepaiement.add(datauser[h]['datepaiement'].toString());
            _prix.add(datauser[h]['montant'].toString());
            montantTot = montantTot +
                (double.parse(datauser[h]['montant']) == null
                    ? 0.0
                    : double.parse(datauser[h]['montant']));
          }
        });
      }
      return datauser;
    } catch (ex) {
      print(
          "====================================================================\n $ex");
    }
  }

  

  Widget _createListViewDet() {
    return Container(
      child: new ListView.builder(
        scrollDirection: Axis.vertical,
        shrinkWrap: true,
        itemCount: _nom.length == null ? 0 : _nom.length,
        itemBuilder: (BuildContext context, int index) {
          //return new Text(_view[index]);

          return Card(
            color: Colors.white,
            elevation: 5.0,
            child: new Column(
              children: <Widget>[
                //topTrier(),
                ListTile(
                  title: Text('${_detailengin[index]}'),
                  subtitle: Text('${_nom[index]}'+' - '+'${_datepaiement[index]}'),
                  leading: Text('${_prix[index]}'+'FC'),
                  onTap: () {},
                ),
              ],
            ),
          );
        },
      ),
    );
  }

  final f = new DateFormat('yyyy-MM-dd');
  DateTime date1 = DateTime.now();
  DateTime date2 = DateTime.now();
  Future<Null> _selectDate1(BuildContext context) async {
    final DateTime picked = await showDatePicker(
      context: context,
      initialDate: DateTime.now(),
      firstDate: DateTime(1900),
      lastDate: DateTime(2099),
    );
    setState(() {
      date1 = picked;
      //CritereSelect.datedep=date1==null? '':f.format(date1).toString();
    });
  }

  Future<Null> _selectDate2(BuildContext context) async {
    final DateTime picked = await showDatePicker(
      context: context,
      initialDate: DateTime.now(),
      firstDate: DateTime(1900),
      lastDate: DateTime(2099),
    );
    setState(() {
      date2 = picked;
      //CritereSelect.dateRet=date2==null? '':f.format(date2).toString();
    });
  }
Widget topTrier(){
  return Column(
                      children: <Widget>[
                        Divider(),
                        Container(
                          color: Colors.white12,
                          child: Column(
                            children: <Widget>[
                              Row(
                                children: <Widget>[
                                  Padding(
                                    padding: const EdgeInsets.only(right: 16.0),
                                    child:
                                        Icon(Icons.date_range, color: Colors.blue),
                                  ),
                                  Expanded(
                                    child: Padding(
                                      padding: const EdgeInsets.only(right: 16.0),
                                      child: TextField(
                                        maxLines: 2,
                                        //controller: datedep,
                                        decoration: InputDecoration(
                                          //icon: Icon(Icons.date_range,color: Colors.grey,),
                                          hintText: 'Du :\n' +
                                              (date1 == null
                                                  ? ''
                                                  : f.format(date1).toString()),
                                        ),
                                        onTap: () {
                                          _selectDate1(context);
                                        },
                                        onChanged: (text) {},
                                      ),
                                    ),
                                  ),
                                  Icon(Icons.navigate_next),
                                  Expanded(
                                    child: Padding(
                                      padding: const EdgeInsets.only(right: 16.0),
                                      child: TextField(
                                        maxLines: 2,
                                        //controller: datedep,
                                        decoration: InputDecoration(
                                          //icon: Icon(Icons.date_range,color: Colors.grey,),
                                          hintText: 'Au :\n' +
                                              (date2 == null
                                                  ? ''
                                                  : f.format(date2).toString()),
                                        ),
                                        onTap: () {
                                          _selectDate2(context);
                                        },
                                        onChanged: (text) {},
                                      ),
                                    ),
                                  ),
                                ],
                              ),
                              Divider(),
                              IconButton(
                                onPressed: () {
                                             _getMontantTot1();
                                  Navigator.pop(context);
                                },
                                icon: Icon(Icons.sort),
                              )
                            ],
                          ),
                        ),
                        Divider(
                          color: Colors.red,
                        ),
                      ],
                    );
}
void showTrie(){
  showModalBottomSheet(
                          context: context,
                          builder: (context){
                           return new Container(
                              color: Color(0xFF737373),
                                  height: MediaQuery.of(context).size.height/2, 
                                  child: Container(
                                    decoration: BoxDecoration(
                                      color: Theme.of(context).canvasColor,
                                      borderRadius: BorderRadius.only(
                                        topLeft: const Radius.circular(10),
                                        topRight: const Radius.circular(10),
                                      )
                                    ),
                                    child: topTrier(),
                                    
                                    ));
                          }
                        );
}
  @override
  Widget build(BuildContext context) {
    
    return 
    //DefaultTabController(
      //length: 2,
     // child:
       Scaffold(
          appBar: AppBar(
              backgroundColor: Colors.white,
              iconTheme: IconThemeData(color: Colors.black),
              centerTitle: true,
              title: new Text(
                '$montantTot \FC',
                style: TextStyle(color: Colors.black),
                
              ),
              actions: <Widget>[
                IconButton(icon: Icon(Icons.sort), onPressed: (){showTrie();})
              ],
              //bottom: 
              // TabBar(
              //   tabs: <Widget>[
              //     Container(height: 180.0,
              //     child: topTrier(),
              //     )
              //   ],
              // )
              ),
//bottomNavigationBar: topTrier(),
          //body here
          body:
              // ListView(
              //   children: <Widget>[
                 // topTrier(),
              _createListViewDet()
          // ],
          // ),
          
    );
  }
}
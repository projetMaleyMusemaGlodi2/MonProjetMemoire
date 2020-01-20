import 'dart:io';
import 'dart:math' as Math;
import 'package:async/async.dart';
import 'package:image/image.dart' as Img;
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:intl/intl.dart';
import 'package:mobilepaie_trans/Classes/components.dart';
import 'package:mobilepaie_trans/Classes/pub.dart';
import 'package:path/path.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:path_provider/path_provider.dart';

class UpdateProfile extends StatefulWidget {
  @override
  _UpdateProfileState createState() => _UpdateProfileState();
}

class _UpdateProfileState extends State<UpdateProfile> {
@override
void initState() { 
  _selection = _items.first;
  super.initState();
  
}


  TextEditingController user= new TextEditingController(),
      nom = new TextEditingController(),
      adresse = new TextEditingController(),
      contact = new TextEditingController(),
      mail = new TextEditingController(),
      typepieceid = new TextEditingController(),
      numeropieceid = new TextEditingController(),
      username = new TextEditingController(),
      password = new TextEditingController(),
      compte = new TextEditingController();
      
      //=================================================================================================
      File _image;

final f=new DateFormat('yyyy-MM-dd');
DateTime date=DateTime.now();
DateTime dateExP=DateTime.now();
void _selectDate(BuildContext context) async{
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
      //==================
      Future getImageGallery() async{
try{
      var imageFile=await ImagePicker.pickImage(source: ImageSource.gallery);

      final tempDir=await getTemporaryDirectory();
      final path=tempDir.path;
      //String title=ctitle.text;
      int rand=new Math.Random().nextInt(1000000);
      Img.Image image=Img.decodeImage(imageFile.readAsBytesSync());
      Img.Image smallerImg=Img.copyResize(image, width:500);
      var compressImg=new File("$path/image_$rand.jpg")
      ..writeAsBytesSync(Img.encodeJpg(smallerImg,quality: 85));

      setState(() {
      _image=compressImg; 
      });
  }catch(ex){
    print('Erreur $ex');
  }

}
Future getImageCamera() async{
try{
var imageFile=await ImagePicker.pickImage(source: ImageSource.camera);
final tempDir=await getTemporaryDirectory();
final path=tempDir.path;
//String title=ctitle.text;
int rand=new Math.Random().nextInt(1000000);
Img.Image image=Img.decodeImage(imageFile.readAsBytesSync());
Img.Image smallerImg=Img.copyResize(image, width:500);
var compressImg=new File("$path/image_$rand.jpg")
..writeAsBytesSync(Img.encodeJpg(smallerImg,quality: 85));

setState(() {
 _image=compressImg; 
});
}catch(ex){
  print('Erreur $ex');
}
}
bool _autoValidate = false;

  //void _value1Changed(bool value) => setState(() => _value1 = value);

  void _validateInputs(File imageFile, BuildContext ctx) {
    if(PubCon.userId=='-1'){
      Fluttertoast.showToast(msg:'Vous n\'etes pas connecté svp!!!',toastLength:Toast.LENGTH_SHORT,
                              backgroundColor:Colors.white,textColor:Colors.red);
    }else{
       if (_formKey.currentState.validate()) {
      //    If all data are correct then save data to out variables
      _formKey.currentState.save();
      //save user in the database
      updateUpdateProfile(imageFile, ctx);
    } else {
      //    If all data are not valid then start auto validation.
      setState(() {
        _autoValidate = true;
      });
    }
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
  final List<String> _items = ['Masculin', 'Feminin'].toList();
  String _selection;
final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  String _email;
  String _password;

  String _imageUpdate;

  void initialiserField()
  {
        PubCon.userNomComplet = nom.text;
        PubCon.userAdresse = adresse.text;
        PubCon.userContact = contact.text;
        PubCon.userMail = mail.text;
        PubCon.userTypepieceid = typepieceid.text;
        PubCon.userNumeropieceid = numeropieceid.text;        
        PubCon.userImage = _imageUpdate;        
        PubCon.username = username.text;
        PubCon.password =password.text;
        PubCon.userSession = username.text; 

  }
//procedure for update
Future updateUpdateProfile(File imageFile, BuildContext ctx) async {
    try{
      //id,noms,adresse,contact,mail,typepieceid,numeropieceid,image,username,password,usersession,compte
        var stream =
        new http.ByteStream(DelegatingStream.typed(imageFile.openRead()));
        var length = await imageFile.length();
        var uri = Uri.parse(PubCon.cheminPhp + "updateClient.php");
        var request = new http.MultipartRequest("POST", uri);
        var multipartFile = new http.MultipartFile("image", stream, length,
        filename: basename(imageFile.path));
        request.fields['id'] =PubCon.userId;
        request.fields['noms'] = nom.text;    
        request.fields['adresse'] = adresse.text;
        request.fields['contact'] = contact.text;
        request.fields['mail'] = mail.text;
        request.fields['typepieceid'] = typepieceid.text;
        request.fields['numeropieceid'] = numeropieceid.text;
        request.fields['username'] = username.text;
        request.fields['password'] = password.text;
        request.fields['usersession'] = username.text;       

        request.files.add(multipartFile);
        var response = await request.send();
        if (response.statusCode == 200) {
          //print("Modification reussi");
          Fluttertoast.showToast(msg:'Modification reussie',toastLength:Toast.LENGTH_SHORT,
                                  backgroundColor:Colors.white,textColor:Colors.black);
          _imageUpdate=basename(imageFile.path);
          initialiserField();
          Navigator.pop(ctx);
        } else {
          //print("Echec de Modification");
          Fluttertoast.showToast(msg:'Echec Modification',toastLength:Toast.LENGTH_SHORT,
                                  backgroundColor:Colors.white,textColor:Colors.red);
        }
    }catch(e){
      print(e);
    }
  }
  @override
  Widget build(BuildContext context) {
    final dropdownMenuOptions = _items
        .map((String item) =>
            new DropdownMenuItem<String>(value: item, child: new Text(item)))
        .toList();
          username.text=PubCon.username;
          nom.text=PubCon.userNomComplet;
          adresse.text=PubCon.userAdresse;
          contact.text=PubCon.userContact;
          mail.text=PubCon.userMail;
          typepieceid.text=PubCon.userTypepieceid;
          numeropieceid.text=PubCon.userNumeropieceid;
          password.text=PubCon.password;
          compte.text=PubCon.userSolde;
    //dateExP=PubCon.userDateExpPass==null? null :DateTime.parse(PubCon.userDateExpPass);
        return Scaffold(
      appBar: AppBar(centerTitle: true,
        title:new Text("UpdateProfile",style: TextStyle(color: Colors.white,fontWeight: FontWeight.bold,)),
        backgroundColor: Colors.blue,),
    body:
      Form(
              key: _formKey,
              autovalidate: _autoValidate,
      child: ListView(
        children: <Widget>[
          
              SizedBox(
                    height: 10,
                  ),
                  Divider(),
                  Row(
                    children: <Widget>[
                      Expanded(
                        child: Column(
                          children: <Widget>[
                            RaisedButton(
                              elevation: 5.0,
                              color: Colors.white,
                              child: Icon(
                                Icons.image,
                                color: Colors.blue,
                              ),
                              onPressed: getImageGallery,
                            ),
                            RaisedButton(
                              elevation: 5.0,
                              color: Colors.white,
                              child: Icon(
                                Icons.camera_alt,
                                color: Colors.blue,
                              ),
                              onPressed: getImageCamera,
                            ),
                          ],
                        ),
                      ),
                      Expanded(
                        child: SizedBox(
                          height: 100.0,
                          child: Align(
                            alignment: Alignment.center,
                              child: _image == null
                                  ? 
                                  Componentss.manageImage(context, PubCon.userImage)
                                  // new Text(
                                  //     "No image selected!",
                                  //     textAlign: TextAlign.center,
                                  //   )
                                  : new Image.file(_image,fit:BoxFit.cover,)),
                        ),
                      )
                    ],
                  ),
                  Divider(),
                  SizedBox(
                    height: 10,
                  ),
                     Divider(),
                    Padding(
                      padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: nom,
                       enabled: true,
                       decoration: InputDecoration(
                         icon: Icon(Icons.supervised_user_circle,color: Colors.grey,),
                         hintText: 'Nom',
                         labelText: 'Nom*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),
                    ),
                    Padding(
                      padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: adresse,
                       enabled: true,
                       decoration: InputDecoration(
                         icon: Icon(Icons.supervised_user_circle,color: Colors.grey,),
                         hintText: 'Adresse',
                         labelText: 'Adresse*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),
                    ),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: contact,
                       enabled: true,
                       decoration: InputDecoration(
                         icon: Icon(Icons.text_fields,color: Colors.grey,),
                         fillColor: Colors.red,
                         hintText: 'Telephone',
                         labelText: 'Telephone*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),),
                   Padding(padding: EdgeInsets.all(2.0),
                    child: TextFormField(
                    onSaved:(value) {
                      if (value.isEmpty) {
                        return 'Entrez votre Adresse Mail';
                      }
                    },
                    obscureText: false,
                    enabled: true,
                    controller: mail,
                    keyboardType: TextInputType.text,
                    style: TextStyle(fontSize: 16, color: Colors.black),
                    textInputAction: TextInputAction.next,
                    decoration: InputDecoration(
                      icon: Icon(Icons.email),
                      labelText: "Adresse Mail *",
                      contentPadding: new EdgeInsets.symmetric(
                          vertical: MediaQuery.of(context).size.height * 0.022,
                          horizontal: 15.0),
                    ),
                  ),),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: typepieceid,
                       enabled: true,
                       decoration: InputDecoration(
                         icon: Icon(Icons.text_fields,color: Colors.grey,),
                         fillColor: Colors.red,
                         hintText: 'Type piéce Indentité',
                         labelText: 'Type piéce Indentité*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: numeropieceid,
                       enabled: true,
                       decoration: InputDecoration(
                         icon: Icon(Icons.text_fields,color: Colors.grey,),
                         fillColor: Colors.red,
                         hintText: 'Numéro piéce Indentité',
                         labelText: 'Numéro piéce Indentité*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextField(
                       controller: username,
                       enabled: false,
                       decoration: InputDecoration(
                         icon: Icon(Icons.text_fields,color: Colors.grey,),
                         fillColor: Colors.red,
                         hintText: 'Username',
                         labelText: 'Username*'
                  //         border: new OutlineInputBorder(
                  //      borderRadius: new BorderRadius.circular(20.0)
                  //  ),
                       ),
                      
                   ),
                    ),
                    Padding(padding: EdgeInsets.all(2.0),
                    child: TextFormField(
                    //focusNode: focusNode3,
                    obscureText: false,
                    enabled: false,
                    controller: password,
                    keyboardType: TextInputType.text,
                    style: TextStyle(fontSize: 16, color: Colors.black),
                    textInputAction: TextInputAction.next,
                    decoration: InputDecoration(
                      icon: Icon(Icons.lock_open),
                      labelText: "Password *",
                      contentPadding: new EdgeInsets.symmetric(
                          vertical: MediaQuery.of(context).size.height * 0.022,
                          horizontal: 15.0),
                      // border: OutlineInputBorder(
                      //   borderRadius: BorderRadius.all(Radius.circular(25)),
                      // ),
                    ),
                  ),
                      ),
                   RaisedButton(
                     child: Text("MODIFIER"),
                     onPressed: (){
                       _validateInputs(_image, context);
                     },
                   )

        ],
      ),
    )
    
    );
    
  }
}
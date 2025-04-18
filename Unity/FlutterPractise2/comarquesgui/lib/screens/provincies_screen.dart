import 'package:comarquesgui/models/provincia.dart';
import 'package:comarquesgui/repository/repository_exemple.dart';
import 'package:comarquesgui/screens/comarques_screen.dart';
import 'package:flutter/material.dart';
import 'package:comarquesgui/repository/repository_comarques.dart';

/* Pantalla ProvinciesScreen: mostra tres CircleAvatar amb les diferents províncies */

class ProvinciesScreen extends StatelessWidget {
  const ProvinciesScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
      future: RepositoryComarques.obtenirProvincies(),
      builder: (context, snapshot)  {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(
            child: CircularProgressIndicator(),
          );
        } else if (snapshot.hasError) {
          return Center(
            child: Text("Error: ${snapshot.error}"),
          );
        } else {
          return Scaffold(                  // Estructura de la pantalla Material Design
            body: Padding(
              padding: const EdgeInsets.all(10.0),
              child: Center(                   // Centrem el contingut
                child: SingleChildScrollView( // Contenidor amb scroll per si ens n'eixim de l'espai disponible
                  child: Column(              // Organitzem les provincies en forma de columna
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children:               // Obtindrem la llista de widgets amb les provincies amb la 
                                              // funció privada _creaLlistaProvincies.
                          _creaLlistaProvincies(RepositoryExemple.obtenirProvincies())),
                ),
              ),
            ),
          );
        }
      },
    );
  }
}

List <Widget> _creaLlistaProvincies(List<Provincia> provincies) {
  // Retornarem una llista de widgets
  List<Widget> llista = [];

  // Recorrem la llista de províncies
  for (Provincia provincia in provincies) {
    llista.add( // I afegim a la llista un widget personalitzat de tipus ProvinciaRoundButton
        ProvinciaRoundButton(img: provincia.imatge ?? "", nom: provincia.nom ?? "", ));
    llista.add(const SizedBox(height: 20)); // Afegim un espai després del widget amb la província
  } 
  return llista;
}

class ProvinciaRoundButton extends StatelessWidget {
  const ProvinciaRoundButton({required this.img, required this.nom, super.key});

  final String img;
  final String nom;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () => {
        Navigator.push(context, MaterialPageRoute(builder: (context) => ComarquesScreen(provincia: nom)))
      },
      child: CircleAvatar(
        radius: 110,
        backgroundImage: NetworkImage(img),
        child: Text(nom, style: Theme.of(context).textTheme.displayMedium),
      ),
    );
  }
}

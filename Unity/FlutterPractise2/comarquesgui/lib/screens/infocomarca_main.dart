import 'package:comarquesgui/screens/infocomarca_detall.dart';
import 'package:comarquesgui/screens/infocomarca_general.dart';
import 'package:flutter/material.dart';

class InfocomarcaMain extends StatefulWidget {
  const InfocomarcaMain({
    required this.comarcaString,
    Key? key,
  }) : super(key: key);

  final String comarcaString;
  @override
  State<InfocomarcaMain> createState() =>
      _ExempleBottomNavigationBarState();
}

class _ExempleBottomNavigationBarState
    extends State<InfocomarcaMain> {
  int indexActual = 0;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: [
          Text('Informació General', style: Theme.of(context).textTheme.labelSmall),
          Text('Població i oratge', style: Theme.of(context).textTheme.labelSmall),
        ][indexActual],
      ),
      bottomNavigationBar: NavigationBar(
        onDestinationSelected: (int index) {
          setState(() {
            indexActual = index;
          });
        },
        selectedIndex: indexActual,
        destinations: const <Widget>[
          NavigationDestination(
            icon: Icon(Icons.info_outline),
            selectedIcon: Icon(Icons.info),
            label: 'Informació general',
          ),
          NavigationDestination(
            icon: Icon(Icons.wb_sunny_outlined),
            selectedIcon: Icon(Icons.wb_sunny),
            label: 'Informació detallada',
          ),
        ],
      ),
      body: <Widget>[
        InfoComarcaGeneral(comarcaString: widget.comarcaString),
        InfoComarcaDetall(comarcaString: widget.comarcaString)
      ][indexActual],
    );
  }
}
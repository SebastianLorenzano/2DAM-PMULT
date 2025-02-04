import 'package:flutter/material.dart';

class LoginScreen extends StatelessWidget {
  const LoginScreen({super.key});
  
  const String LOGIN_USER: "admin";

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        const Text("Iniciar Sesión"),
        TextField(
          decoration: const InputDecoration(
            hintText: "Usuario",
          ),
        ),
        TextField(
          decoration: const InputDecoration(
            hintText: "Contraseña",
          ),
        ),
        ElevatedButton(
          onPressed: (if ()) {
            Navigator.push<void>(
              context,
              MaterialPageRoute<void>(
                builder: (BuildContext context) => const LauncherScreen(),
              ),
            );
          },
          child: const Text("Iniciar Sesión"),
        ),
      ],
    )
  }
}
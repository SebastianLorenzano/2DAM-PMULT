import 'package:comarquesgui/screens/launcher_screen.dart';
import 'package:flutter/material.dart';

class LoginScreen extends StatelessWidget {
  LoginScreen({super.key});
  
  static const String LOGIN_USER = "admin";
  static const String LOGIN_PASSWORD = "admin";
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  TextEditingController userController = TextEditingController();
  TextEditingController passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Form(
      key: _formKey,
      child: Center(
        child: Padding(
          padding: const EdgeInsets.all(15.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text("Iniciar Sesión", style: Theme.of(context).textTheme.titleSmall,),
              const SizedBox(height: 20),
              TextFormField(
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "No puede estar vacío";
                  }
                  if (value != LOGIN_PASSWORD) {
                    return "La dirección de correo no es válida";
                  }
                  return null;
                },
                autofocus: true,
                keyboardType: TextInputType.emailAddress,
                controller: userController,
                decoration: InputDecoration(
                  hintText: "Correo Electronico",
                  border: OutlineInputBorder(borderRadius: BorderRadius.circular(20)),
                  icon: const Icon(Icons.email_rounded),
                ),
              ),
              const SizedBox(height: 20),
              TextFormField(
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "No puede estar vacío";
                  }
                  if (value != LOGIN_PASSWORD) {
                    return "La contraseña no es válida";
                  }
                  return null;
                },
                obscureText: true,
                controller: passwordController,
                decoration: InputDecoration(
                  hintText: "Contraseña",
                  border: OutlineInputBorder(borderRadius: BorderRadius.circular(20)),
                  icon: const Icon(Icons.lock),
                ),
              ),
              const SizedBox(height: 20),
              ElevatedButton(
                style: ButtonStyle(
                  shape: WidgetStateProperty.all<RoundedRectangleBorder>(const RoundedRectangleBorder(borderRadius: BorderRadius.zero)
                  )
                ),
                onPressed: () {
                  if (_formKey.currentState?.validate() ?? true) {
                    Navigator.push(context, MaterialPageRoute(builder: (context) => const LauncherScreen()));
                  }
                },
                child: const Text("Iniciar Sesión"),
              ),
            ],
          ),
        ),
      ),
    );
  }

}
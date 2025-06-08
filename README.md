
# 🐶 DogiDogEscritorio

**DogiDogEscritorio** es una aplicación de escritorio desarrollada en **C# con Windows Forms**. Forma parte del ecosistema DogiDog y está centrada en la gestión administrativa de usuarios, razas de perros, incidencias, notificaciones, valoraciones y empleados.  
Cuenta con una interfaz visual adorable, colorida y profesional, con una estética "cute" que hace que sea un placer trabajar con ella. 🐾

---

## ✨ Funcionalidades principales

### 🔐 Login seguro
- Solo los usuarios que son empleados pueden iniciar sesión.
- Verificación de credenciales mediante la API REST.
- Interfaz con estilo moderno, íconos y emojis.

### 🐾 Gestión de razas
- Crear, editar, eliminar y listar razas de perros.
- Visualización de características como energía, inteligencia, cuidado, socialización, etc.
- Muestra un gráfico de radar con estadísticas.
- Incluye descripciones y datos curiosos.

### ⚠️ Gestión de incidencias
- Registro de nuevas incidencias.
- Selección de empleado asignado mediante combo box.
- Comunicación directa con la API REST.

### 📬 Envío de notificaciones
- Visualización de usuarios registrados en un DataGridView.
- Selección múltiple para enviar notificaciones.
- Interfaz clara y amigable para comunicar novedades.

### 💬 Gestión de valoraciones
- Visualiza valoraciones realizadas entre usuarios.
- Filtro por email del usuario que valora.
- Permite eliminar la cuenta del usuario valorado directamente desde el formulario.

### 👥 Gestión de cuentas (empleados)
- Crear un nuevo empleado registrando primero el usuario.
- Editar puesto, administrador y contraseña según quién edita.
- Reset de contraseña a '1234' por parte de administradores.
- Eliminar cuenta de empleado.
- Estilo visual encantador con tarjetas y botones personalizados.

### 🤖 DogiBot (FAQ inteligente)
- Gestión de preguntas y respuestas del bot DogiBot.
- CRUD completo (agregar, editar, eliminar).
- Sincronizado con la API.

---

## 🧱 Estructura de carpetas

```
DogiDogEscritorio/
│
├── Forms/
│   ├── LoginForm.cs
│   ├── RazasForm.cs
│   ├── NuevaIncidenciaForm.cs
│   ├── NotificacionesForm.cs
│   ├── ValoracionesForm.cs
│   ├── CuentasForm.cs
│   ├── EditarEmpleadoForm.cs
│   └── DogiBotForm.cs
│
├── Models/
│   ├── Usuario.cs
│   ├── Empleado.cs
│   ├── Raza.cs
│   ├── Incidencia.cs
│   ├── Valoracion.cs
│   ├── Notificacion.cs
│   └── EntradaBot.cs
│
├── Services/
│   └── Servicios para conexión con API REST
│
└── Program.cs
```

---

## 🎨 Estilo visual

- Paleta de colores: Azul pastel, celeste y blanco.
- Fuentes: **Segoe UI**.
- Paneles tipo tarjeta con bordes suaves.
- Uso de emojis e íconos 🐾.
- Interfaz moderna, accesible y encantadora.

---

## 🚀 Cómo ejecutar la aplicación

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tuusuario/DogiDogEscritorio.git
   ```

2. Abre el proyecto en **Visual Studio**.

3. Asegúrate de que la **API REST** esté corriendo (local o en servidor).

4. Ejecuta la aplicación (F5) y comienza a disfrutar. 🐶

---

## 📌 Requisitos

- Windows 10 o superior.
- .NET Framework compatible con WinForms.
- API REST DogiDog funcionando correctamente.

---

## 🛠️ Funcionalidades futuras (opcional)

- Modo oscuro 🌙.
- Estadísticas avanzadas.
- Multilenguaje (es/en).

---

## 💖 Créditos

Desarrollado con cariño y pasión por los perritos.  
Con una estética cute y funcional, para que la gestión sea tan encantadora como efectiva.  
**¡Gracias por usar DogiDogEscritorio! 🐕✨**

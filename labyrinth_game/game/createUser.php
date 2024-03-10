<?php
include "dbConnection.php";

try{
  $conn = mysqli_connect($servidor, $usuario, $pass, $baseDatos);
  if(!$conn)
  {
    echo '{"codigo":400, "mensaje":"error intentando conectar", "respuesta":""}';
  } else {
    if( isset($_POST['nombre']) &&
        isset($_POST['apellido']) &&
        isset($_POST['correo']) &&
        isset($_POST['edad']) &&
        isset($_POST['user']) &&
        isset($_POST['password']))
        {
          $nombre           = $_POST['nombre'];
          $apellido         = $_POST['apellido'];
          $correo           = $_POST['correo'];
          $edad             = $_POST['edad'];
          $user             = $_POST['user'];
          $password         = $_POST['password'];


          $sql = "SELECT * FROM `usuario` WHERE user = '".$user."';";
          $resultado = $conn->query($sql);
          if($resultado->num_rows > 0)
          {
            echo '{"codigo":403, "mensaje":"Ya existe un usuario registrado", "respuesta":"'.$resultado->num_rows.'"}';
          }
          else
          {
            $sql = "SELECT * FROM `usuario` WHERE correo = '".$correo."';";
            $resultado = $conn->query($sql);
            if($resultado->num_rows > 0)
            {
                echo '{"codigo":405, "mensaje":"Ya existe este correo", "respuesta":"'.$resultado->num_rows.'"}';
            }
            else {
              $sql = "INSERT INTO `usuario` (`nombre`, `apellido`, `correo`,`edad`, `user`, `password`)
              VALUES ('".$nombre."', '".$apellido."', '".$correo."', '".$edad."', '".$user."', '".$password."');";

              if($conn->query($sql) === true)
              {
                $sql = "SELECT * FROM `usuario` WHERE user = '".$user."';";
                $resultado = $conn->query($sql);
                $texto = '';

                while($row = $resultado->fetch_assoc())
                {
                  $texto = "{#nombre#: ".$row['nombre'].", #apellido#: ".$row['apellido'].",
                    #correo#: ".$row['correo'].",  #edad#: ".$row['edad'].",
                    #user#: ".$row['user'].", #password#: ".$row['password']."}";
                }
                echo '{"codigo":201, "mensaje":"conectado correctamente", "respuesta":""}';
              }
              else
              {
                echo '{"codigo":401, "mensaje":"error conexion", "respuesta":""}';
              }
            }
          }
        }
        else{
            echo '{"codigo":402, "mensaje":"faltan datos para ejecutar la acción solicitada", "respuesta":""}';
    }
  }
}
catch(Exception $e)
{
  echo '{"codigo":400, "mensaje":"error intentando conectar", "respuesta":""}';
}


include 'footer.php';

<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json");
$file = 'database.json';
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $data = file_get_contents('php://input');
    if (file_put_contents($file, $data)) echo json_encode(["status" => "ok"]);
    else http_response_code(500);
} else {
    echo file_exists($file) ? file_get_contents($file) : json_encode(["funcionarios"=>[], "projetos"=>[]]);
}
?>
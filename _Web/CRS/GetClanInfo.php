<?php

$clanTag = $_GET['ClanTag'];

$curl_h = curl_init('https://api.clashroyale.com/v1/clans/%23'.$clanTag.'/members');

curl_setopt($curl_h, CURLOPT_HTTPHEADER,
    array(
        'Content-Type: application/x-www-form-urlencoded',
        'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImNlNmNiM2NiLWFmYTMtNGQ0ZC1hYzNiLTNjNjIxYjBjMGY3ZiIsImlhdCI6MTYwODQxNjE5Miwic3ViIjoiZGV2ZWxvcGVyLzQzZDg3MDJiLTFmMDctYzg4OC0wNjM5LWQ1YjE3YjdiN2UzNCIsInNjb3BlcyI6WyJyb3lhbGUiXSwibGltaXRzIjpbeyJ0aWVyIjoiZGV2ZWxvcGVyL3NpbHZlciIsInR5cGUiOiJ0aHJvdHRsaW5nIn0seyJjaWRycyI6WyIxODUuMTI5LjEzOC4zMSIsIjE4NS4xMjkuMTM4LjMyIiwiMTg1LjEyOS4xMzguMzMiLCIxODUuMTI5LjEzOC4zNCIsIjE4NS4xMjkuMTM4LjM1Il0sInR5cGUiOiJjbGllbnQifV19.EJrOcy8z0FLlKlvMRy33mv5n3gnZUH9RkKqE0aq9U73yMU-IjzI5L3R2zVFEVmWe0vQzOGgFUxy_tT-UUFShqg
'
    )
);

# do not output, but store to variable
curl_setopt($curl_h, CURLOPT_RETURNTRANSFER, true);

$response = curl_exec($curl_h);

echo $response;

?>
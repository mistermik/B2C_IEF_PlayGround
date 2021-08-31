# REST API Call and JSON claims transformations
https://docs.microsoft.com/en-us/azure/active-directory-b2c/json-transformations#generatejson

**Example of id_token returned by B2C**
```
{
  "typ": "JWT",
  "alg": "RS256",
  "kid": "RvTebkQvD5wco5L0mFixX1Po33OAgVmLrin5zk80JE8"
}.{
  "exp": 1630384039,
  "nbf": 1630380439,
  "ver": "1.0",
  "iss": "https://xxxxxxx.b2clogin.com//v2.0/",
  "sub": "xxxxxxx-xxxxxxx-xxxxxxx-xxxxxxx-xxxxxxx",
  "aud": "xxxxxxx-xxxxxxx-xxxxxxx-xxxxxxx-xxxxxxx",
  "acr": "b2c_1a_rest_signup_signin",
  "nonce": "defaultNonce",
  "iat": 1630380439,
  "auth_time": 1630380439,
  "name": "Mister Mik",
  "given_name": "Mister",
  "family_name": "Mik",
  "house": "Single",
  "rate": "Monthly",
  "color": "White",
  "random_field": "5576",
  "custom_payload_claim" :{ 
       "house":"Single",
			 "rate":"Monthly",
			 "color":"White",
			 "random_field":"5576"}
  "tid": "xxxxxxx-xxxxxxx-xxxxxxx-xxxxxxx-xxxxxxx"
}.[Signature]

# REST API Custom Integration with B2C Custom Policy

**REST API call output:**
```
{
    "version": "1.0.0.0",
    "status": 200,
    "userMessage": "",
    "loyaltyNumber": null,
    "email": null,
    "house": "Apartment",
    "rate": "Premium",
    "color": "Yellow",
    "random_field": "5183",
    "custom_payload": [
        "Apartment",
        "Premium",
        "Yellow",
        "5183"
    ],
    "action": "Continue",
    "allowedToLogin": true,
    "enforceMFA": true,
    "forceChangePassword": false
}
```
if enforceMFA= true -> force MFA
if enforceMFA= false -> No MFA

if forceChangePassword=true -> force password Reset

if allowedToLogin = false -> Show Block Page

**Example of id_token returned by B2C to the RP**

```
{
  "typ": "JWT",
  "alg": "RS256",
  "kid": "XXXXX"
}.{
  "exp": 1630459342,
  "nbf": 1630455742,
  "ver": "1.0",
  "iss": "https://XXXXX.b2clogin.com/XXXXX-XXXXX-XXXXX-XXXXX-XXXXX/v2.0/",
  "sub": "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX",
  "aud": "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX",
  "acr": "b2c_1a_rest_signup_signin",
  "nonce": "defaultNonce",
  "iat": 1630455742,
  "auth_time": 1630455742,
  "name": "Mister Mik",
  "given_name": "Mister",
  "family_name": "Mik",
  "allowedToLogin": true,
  "enforceMFA": false,
  "forceChangePassword": false,
  "custom_payload": [
    "Condos",
    "PayAsYouGo",
    "Brown",
    "4697"
  ],
  "tid": "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"
}.[Signature]
```

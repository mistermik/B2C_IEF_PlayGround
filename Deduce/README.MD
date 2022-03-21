 self-asserted technical profile with javascript reading user_agent into the claims bag and automatically click the continue button
 
Based on: https://login.microsoftonline.com/static/tenant/templates/AzureBlue/selfAsserted.cshtml

**selfAsserted.cshtml:** 
Hiding panel-default
```html
        <style>
            .panel-default   {
            margin: 0 auto;
            width: 60%;
            height: 0px;
            background-color: #296ec6;
            opacity: 1;
            border-radius: .5rem;
            border: none;
            color: #fff;
            font-size: 1em;
            box-shadow: 0 0 30px 0 #dae1f7;
            visibility: hidden;
        }
 ``` 
<!-- Javascript script to read user_agent and submit -->
  
        <script>
             $("#user_agent").hide().val(window.navigator.userAgent);
            var img = new Image();
            img.onload = function() {
                document.getElementById("continue").click();
            };
            img.src = "https://login.microsoftonline.com/static/tenant/templates/images/logo.svg";
        </script>
        

  User Journey:
  ```xml
   <UserJourney Id="SignUpOrSignIn_WithDeduce">
      <OrchestrationSteps>
        <OrchestrationStep Order="1" Type="ClaimsExchange">
          <ClaimsExchanges>
            <ClaimsExchange Id="Browser-UserAgent" TechnicalProfileReferenceId="SelfAsserted-UserAgent" />
          </ClaimsExchanges>
        </OrchestrationStep>
        <..>
```
         
**Technical Profile:**
```xml        
<TechnicalProfile Id="SelfAsserted-UserAgent">
          <DisplayName>Pre-login</DisplayName>
          <Protocol Name="Proprietary" Handler="Web.TPEngine.Providers.SelfAssertedAttributeProvider, Web.TPEngine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
          <Metadata>
            <Item Key="ContentDefinitionReferenceId">api.selfassertedDeduce</Item>
            <!-- <Item Key="ContentDefinitionReferenceId">api.signuporsignin</Item> -->
            <Item Key="setting.showCancelButton">false</Item>
            <!-- <Item Key="setting.showContinueButton">false</Item> -->
            <!-- <Item Key="setting.showSignupLink ">false</Item> -->
            <Item Key="language.button_continue">Continue</Item>
          </Metadata>
          <OutputClaims>
            **<OutputClaim ClaimTypeReferenceId="user_agent" />**
          </OutputClaims>
</TechnicalProfile>
```
         
**Content Definition:**
```xml
<ContentDefinition Id="api.selfassertedDeduce">
        <LoadUri>https://b2cdfpj.blob.core.windows.net/isv/selfAsserted.cshtml</LoadUri>
        <RecoveryUri>~/common/default_page_error.html</RecoveryUri>
        <DataUri>urn:com:microsoft:aad:b2c:elements:contract:selfasserted:2.1.7</DataUri>
        <Metadata>
          <Item Key="DisplayName">Signin and Signup Deduce</Item>
        </Metadata>
</ContentDefinition>
```

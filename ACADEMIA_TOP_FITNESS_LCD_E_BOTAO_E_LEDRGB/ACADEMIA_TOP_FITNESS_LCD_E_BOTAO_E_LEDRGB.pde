#include <LiquidCrystal.h> // declara a utilização da biblioteca LiquidCrystal
/* / ->> APAGAR TUDO
   | ->> LOGO
   { ->> ESCREVER LINHA DE CIMA
   } ->> ESCREVER LINHA DE BAIXO
   & ->> VERDE
   # ->> vermelho
   % ->> azul
   $ ->> s/cor
*/
#define btnRIGHT  0
#define btnUP     1
#define btnDOWN   2
#define btnLEFT   3
#define btnSELECT 4
#define btnNONE   5

//cria um objeto tipo LiquidCrystal que chamei de "lcd" nos pinos citados:
LiquidCrystal lcd(8, 9, 4, 5, 6, 7);
int dec;
String convertido;
String linha2;

void setup()
{
  Serial.begin(9600);
lcd.begin(16, 2); // Iniciando o objeto "lcd" de 2 linhas e 16 colunas
logo();
}

void loop()
{
  int botao = lerBotoesLCD();
  
  if(botao == 3)
  {
    Serial.print(0);
 //   lcd.print("cancelar");
    delay(100);
  }
  if(botao == 4)
  {
    Serial.print(1);
 //   lcd.print("selecionar");
    delay(100);
  }
  if(botao == 1)
  {
    Serial.print(2);
 //   lcd.print("cima");
    delay(100);
  }
  if(botao ==2)
  {
    Serial.print(3);
  //  lcd.print("baixo");
    delay(100);
  }
  
  
  if(Serial.available() >0)
  {   
    dec = Serial.read();
    
    if(dec == 38)
    {
      ativaRgb(0,0,255);
      //LED AZUL
    }
    if(dec == 35)
    {
      ativaRgb(255,0,0);
     //LED vermelho 
    }
    
    if(dec == 37)
    {
      ativaRgb(0,255,0);
      //LED verde
    }
    if(dec == 36)
    {
      ativaRgb(0,0,0);
      //APAGA LED
    }
    if(dec == 47)
    {
      lcd.clear();
      //limpar tela
    } 
    if(dec == 124)
    {
      logo();
      //logoTipo
    }
    if(dec == 123)
    {
      lcd.setCursor(0,0);
      //cursor primeira linha, primeira letra
    }
    if(dec == 125)
    {
      lcd.setCursor(0,1);
      //cursor segunda linha, segunda letra
    }
    if(dec!= 47 && dec!= 124 && dec!= 123 && dec!= 125 && dec != 38 && dec != 35 && dec != 36 && dec != 37)
    {
      //escrever na tela
      String resp = converter(dec);
      lcd.print(resp);
    }
  }
}

void ativaRgb(int redVal,int greenVal, int blueVal){
analogWrite(13 , redVal); // Escreve o valor do PWM do led vermelho
analogWrite(2, greenVal); // Escreve o valor do PWM do led verde
analogWrite(3, blueVal); // Escreve o valor do PWM do led azul
}

int lerBotoesLCD()
{ 
int adc_key_in = analogRead(0);      
// read the value from the sensor  
// my buttons when read are centered at these valies: 0, 144, 329, 504, 741 
// we add approx 50 to those values and check to see if we are close 
if (adc_key_in > 1000) 
return btnNONE; 
// lê o valor da porta analogica, e se for esses, vai retornar tal valor 
if (adc_key_in < 50)   
return btnRIGHT;   
if (adc_key_in < 195)  
return btnUP;  
if (adc_key_in < 380)  
return btnDOWN;  
if (adc_key_in < 555)  
return btnLEFT;  
if (adc_key_in < 790)  
return btnSELECT;    


return btnNONE;  // se todas as de cima falharem, retorna nada
}

void logo()
{
  lcd.clear();
lcd.setCursor(0,0);
lcd.print("TOP FITNESS ");
byte peso[8] = {
0b00000,
0b01110,
0b01110,
0b01110,
0b01110,
0b01110,
0b01110,
0b00000 };
lcd.createChar(1,peso);
lcd.setCursor(12,0);
lcd.write(1);
lcd.setCursor(13,0);
lcd.print("--");
lcd.setCursor(15,0);
lcd.write(1);
lcd.setCursor(0,1);
}

String converter(int dec)
{
  String resp = "";
  switch(dec)
  {
case 32:
resp = ' ';
break;

case 33:
resp = '!';
break;

case 40:
resp = '(';
break;

case 41:
resp = ')';
break;

case 45:
resp = '-';
break;

case 48:
resp = '0';
break;

case 49:
resp = '1';
break;

case 50:
resp = '2';
break;

case 51:
resp = '3';
break;

case 52:
resp = '4';
break;

case 53:
resp = '5';
break;

case 54:
resp = '6';
break;

case 55:
resp = '7';
break;

case 56:
resp = '8';
break;

case 57:
resp = '9';
break;

case 58:
resp = ':';
break;

case 59:
resp = ';';
break;

case 60:
resp = '<';
break;

case 61:
resp = '=';
break;

case 62:
resp = '>';
break;

case 63:
resp = '?';
break;

case 64:
resp = '@';
break;

case 65:
resp = 'A';
break;

case 66:
resp = 'B';
break;

case 67:
resp = 'C';
break;

case 68:
resp = 'D';
break;

case 69:
resp = 'E';
break;

case 70:
resp = 'F';
break;

case 71:
resp = 'G';
break;

case 72:
resp = 'H';
break;

case 73:
resp = 'I';
break;

case 74:
resp = 'J';
break;

case 75:
resp = 'K';
break;

case 76:
resp = 'L';
break;

case 77:
resp = 'M';
break;

case 78:
resp = 'N';
break;

case 79:
resp = 'O';
break;

case 80:
resp = 'P';
break;

case 81:
resp = 'Q';
break;

case 82:
resp = 'R';
break;

case 83:
resp = 'S';
break;

case 84:
resp = 'T';
break;

case 85:
resp = 'U';
break;

case 86:
resp = 'V';
break;

case 87:
resp = 'W';
break;

case 88:
resp = 'X';
break;

case 89:
resp = 'Y';
break;

case 90:
resp = 'Z';
break;

case 91:
resp = '[';
break;

case 93:
resp = ']';
break;

case 95:
resp = '_';
break;

case 97:
resp = 'a';
break;

case 98:
resp = 'b';
break;

case 99:
resp = 'c';
break;

case 100:
resp = 'd';
break;

case 101:
resp = 'e';
break;

case 102:
resp = 'f';
break;

case 103:
resp = 'g';
break;

case 104:
resp = 'h';
break;

case 105:
resp = 'i';
break;

case 106:
resp = 'j';
break;

case 107:
resp = 'k';
break;

case 108:
resp = 'l';
break;

case 109:
resp = 'm';
break;

case 110:
resp = 'n';
break;

case 111:
resp = 'o';
break;

case 112:
resp = 'p';
break;

case 113:
resp = 'q';
break;

case 114:
resp = 'r';
break;

case 115:
resp = 's';
break;

case 116:
resp = 't';
break;

case 117:
resp = 'u';
break;

case 118:
resp = 'v';
break;

case 119:
resp = 'w';
break;

case 120:
resp = 'x';
break;

case 121:
resp = 'y';
break;

case 122:
resp = 'z';
break;
  }
return resp;
}

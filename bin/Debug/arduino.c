int length = 512;
const int REST = -1;
int notes[] = {1318, REST, 1318, REST, 1318, REST, 1046, REST, 1318, REST, 1568, REST, REST, 1046, REST, REST, 784, REST, REST, 659, REST, REST, 880, REST, 987, REST, 932, REST, 880, REST, 784, REST, 1318, REST, 1568, REST, 1760, REST, 1397, REST, 1568, REST, 1318, REST, 1046, REST, 1174, REST, 987, REST, REST, 1046, REST, REST, 784, REST, REST, 659, REST, REST, 880, REST, 987, REST, 932, REST, 880, REST, 784, REST, 1318, REST, 1568, REST, 1760, REST, 1397, REST, 1568, REST, 1318, REST, 1046, REST, 1174, REST, 987, REST, REST, 1568, REST, 1480, REST, 1397, REST, 1244, REST, 1318, REST, 830, REST, 880, REST, 1046, REST, 880, REST, 1046, REST, 1174, REST, REST, 1568, REST, 1480, REST, 1397, REST, 1244, REST, 1318, REST, 2093, REST, 2093, REST, 2093, REST, REST, 1568, REST, 1480, REST, 1397, REST, 1244, REST, 1318, REST, 830, REST, 880, REST, 1046, REST, 880, REST, 1046, REST, 1174, REST, REST, 1244, REST, REST, 1174, REST, REST, 1046, REST, REST, 1568, REST, 1480, REST, 1397, REST, 1244, REST, 1318, REST, 830, REST, 880, REST, 1046, REST, 880, REST, 1046, REST, 1174, REST, REST, 1568, REST, 1480, REST, 1397, REST, 1244, REST, 1318, REST, 2093, REST, 2093, REST, 2093, REST, REST, 1568, REST, 1480, REST, 1397, REST, 1244, REST, 1318, REST, 830, REST, 880, REST, 1046, REST, 880, REST, 1046, REST, 1174, REST, REST, 1244, REST, REST, 1174, REST, REST, 1046, REST, REST, 1046, REST, 1046, REST, 1046, REST, 1046, REST, 1174, REST, 1318, REST, 1046, REST, 880, REST, 784, REST, REST, 1046, REST, 1046, REST, 1046, REST, 1046, REST, 1174, REST, 1318, REST, REST, 1046, REST, 1046, REST, 1046, REST, 1046, REST, 1174, REST, 1318, REST, 1046, REST, 880, REST, 784, REST, REST, 1318, REST, 1318, REST, 1318, REST, 1046, REST, 1318, REST, 1568, REST, REST, 1046, REST, REST, 784, REST, REST, 659, REST, REST, 880, REST, 987, REST, 932, REST, 880, REST, 784, REST, 1318, REST, 1568, REST, 1760, REST, 1397, REST, 1568, REST, 1318, REST, 1046, REST, 1174, REST, 987, REST, REST, 1046, REST, REST, 784, REST, REST, 659, REST, REST, 880, REST, 987, REST, 932, REST, 880, REST, 784, REST, 1318, REST, 1568, REST, 1760, REST, 1397, REST, 1568, REST, 1318, REST, 1046, REST, 1174, REST, 987, REST, REST, 1318, REST, 1046, REST, 784, REST, REST, 830, REST, 880, REST, 1397, REST, 1397, REST, 880, REST, REST, 987, REST, 1760, REST, 1760, REST, 1760, REST, 1568, REST, 1397, REST, 1318, REST, 1046, REST, 880, REST, 784, REST, REST, 1318, REST, 1046, REST, 784, REST, REST, 830, REST, 880, REST, 1397, REST, 1397, REST, 880, REST, REST, 987, REST, 1397, REST, 1397, REST, 1397, REST, 1318, REST, 1174, REST, 1046, REST, REST, 1318, REST, 1046, REST, 784, REST, REST, 830, REST, 880, REST, 1397, REST, 1397, REST, 880, REST, REST, 987, REST, 1760, REST, 1760, REST, 1760, REST, 1568, REST, 1397, REST, 1318, REST, 1046, REST, 880, REST, 784, REST, REST, 1318, REST, 1046, REST, 784, REST, REST, 830, REST, 880, REST, 1397, REST, 1397, REST, 880, REST, REST, 987, REST, 1397, REST, 1397, REST, 1397, REST, 1318, REST};
const PROGMEM int noteLength[] = {71, 71, 71, 142, 71, 142, 71, 71, 71, 142, 71, 571, 142, 71, 285, 71, 71, 285, 71, 71, 285, 71, 71, 142, 71, 142, 71, 71, 71, 142, 71, 142, 71, 71, 142, 71, 71, 142, 71, 71, 71, 142, 71, 142, 71, 71, 71, 71, 71, 285, 71, 71, 285, 71, 71, 285, 71, 71, 285, 71, 71, 142, 71, 142, 71, 71, 71, 142, 71, 142, 71, 71, 142, 71, 71, 142, 71, 71, 71, 142, 71, 142, 71, 71, 71, 71, 71, 571, 71, 71, 71, 71, 71, 71, 71, 71, 142, 71, 142, 71, 71, 71, 71, 71, 142, 71, 71, 71, 71, 71, 285, 71, 71, 71, 71, 71, 71, 71, 71, 142, 71, 142, 71, 142, 71, 71, 71, 571, 142, 71, 71, 71, 71, 71, 71, 71, 142, 71, 142, 71, 71, 71, 71, 71, 142, 71, 71, 71, 71, 71, 285, 71, 71, 285, 71, 71, 285, 71, 71, 1142, 142, 71, 71, 71, 71, 71, 71, 71, 142, 71, 142, 71, 71, 71, 71, 71, 142, 71, 71, 71, 71, 71, 285, 71, 71, 71, 71, 71, 71, 71, 71, 142, 71, 142, 71, 142, 71, 71, 71, 571, 142, 71, 71, 71, 71, 71, 71, 71, 142, 71, 142, 71, 71, 71, 71, 71, 142, 71, 71, 71, 71, 71, 285, 71, 71, 285, 71, 71, 285, 71, 71, 571, 142, 71, 71, 71, 142, 71, 142, 71, 71, 71, 142, 71, 71, 71, 142, 71, 71, 71, 285, 71, 71, 71, 71, 142, 71, 142, 71, 71, 71, 71, 71, 1142, 71, 71, 71, 71, 142, 71, 142, 71, 71, 71, 142, 71, 71, 71, 142, 71, 71, 71, 285, 71, 71, 71, 71, 142, 71, 142, 71, 71, 71, 142, 71, 571, 142, 71, 285, 71, 71, 285, 71, 71, 285, 71, 71, 142, 71, 142, 71, 71, 71, 142, 71, 142, 71, 71, 142, 71, 71, 142, 71, 71, 71, 142, 71, 142, 71, 71, 71, 71, 71, 285, 71, 71, 285, 71, 71, 285, 71, 71, 285, 71, 71, 142, 71, 142, 71, 71, 71, 142, 71, 142, 71, 71, 142, 71, 71, 142, 71, 71, 71, 142, 71, 142, 71, 71, 71, 71, 71, 285, 71, 71, 71, 71, 142, 71, 285, 71, 71, 142, 71, 71, 71, 142, 71, 71, 71, 285, 71, 71, 142, 71, 71, 142, 71, 71, 142, 71, 71, 142, 71, 71, 71, 71, 142, 71, 71, 71, 285, 71, 71, 71, 71, 142, 71, 285, 71, 71, 142, 71, 71, 71, 142, 71, 71, 71, 285, 71, 71, 71, 71, 142, 71, 71, 71, 142, 71, 71, 142, 71, 71, 571, 142, 71, 71, 71, 142, 71, 285, 71, 71, 142, 71, 71, 71, 142, 71, 71, 71, 285, 71, 71, 142, 71, 71, 142, 71, 71, 142, 71, 71, 142, 71, 71, 71, 71, 142, 71, 71, 71, 285, 71, 71, 71, 71, 142, 71, 285, 71, 71, 142, 71, 71, 71, 142, 71, 71, 71, 285, 71, 71, 71, 71, 142, 71, 71, 71, 142, 71, 71};

from ctypes import *

lib = CDLL('./librev.so') 
text = raw_input('Text to process: ')
lib.ProcessBuffer(text, len(text)) 
print 'Processed text:', text





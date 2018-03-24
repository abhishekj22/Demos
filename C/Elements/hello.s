.intel_syntax

.include "console.i"

.text

greet:	.ascii	"Hello World!"

_entry:
	lea	%ebx, greet
	PutStr	%ebx, 12	#length of string=12
	PutEOL	

	ret

.global	_entry


.end





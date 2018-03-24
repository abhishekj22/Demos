.intel_syntax noprefix

.include "console.i"

.data

index:	.long	0
value:	.long	0

.text

array:	.long	111, 222, 333, 444, 555, 666, 777, 888
ask:	.asciz	"Index (0-7): "
ans:	.asciz	"Value = "
fin:	.asciz	"Goodbye."

_entry:
	Prompt	ask
	GetInt	index

	mov	esi, index		#direct addressing
	lea	ebx, array	
	mov	eax, [ebx+4*esi]	#indirect addressing
	mov	value, eax

	Prompt	ans
	PutInt	value
	PutEOL
	Prompt	fin
	PutEOL

	ret

.global _entry

.end
















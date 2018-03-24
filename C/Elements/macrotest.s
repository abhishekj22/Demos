.intel_syntax noprefix

.include "console.i"
.include "mymacro.i"

.data

number:	.long	0
digits:	.long	0

.text

ask:	.asciz	"Enter a positive integer: "
ans:	.asciz	"Number of digits = "

_entry:
	Prompt	ask
	GetInt	number

	mov	eax, 1
	mov	ebx, number
	mov	ecx, 0
	cmp	ebx, 0
	jge	1f
	neg	ebx

1:	Mul10	eax	
	inc	ecx		#add	ecx, 1

	cmp	eax, ebx
	jbe	1b

	mov	digits, ecx

	Prompt	ans
	PutInt	digits
	PutEOL

	ret

.global _entry

.end



















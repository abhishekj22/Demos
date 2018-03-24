.intel_syntax noprefix

.text

_GCD:
1:	cmp	eax, ecx
	je	3f

	ja	2f

	sub	ecx, eax
	jmp	1b

2:	sub	eax, ecx
	jmp	1b

3:	ret

.global	_GCD

.end












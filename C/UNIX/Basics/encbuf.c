int ProcessBuffer(char bytes[], int count)
{
	register int i;

	for(i = 0; i < count; ++i)
	{
		if(bytes[i] != ' ')
			bytes[i] ^= '#';
	}

	return i;
}





#include "StringHelper.h"

JNIEXPORT jint JNICALL Java_StringHelper_hashOf(JNIEnv* env, jclass, jstring str)
{
	jint n = env->GetStringLength(str);
	jboolean iscopy;
	const jchar* buffer = env->GetStringChars(str, &iscopy);
	jint hash = 0;

	for(jint i = 0; i < n; ++i)
		hash = buffer[i] + (hash << 6) + (hash << 16) - hash;

	env->ReleaseStringChars(str, buffer);

	return hash;
}

JNIEXPORT jstring JNICALL Java_StringHelper_reverseOf(JNIEnv* env, jclass, jstring str)
{
	jint n = env->GetStringLength(str);
	jchar* buffer = new jchar[n];
	env->GetStringRegion(str, 0, n, buffer);

	for(jchar i = 0, j = n - 1; i < j; ++i, j--)
	{
		jchar ic = buffer[i];
		jchar jc = buffer[j];
		buffer[i] = jc;
		buffer[j] = ic;
	}

	jstring reversed = env->NewString(buffer, n);
	delete[] buffer;

	return reversed;
}

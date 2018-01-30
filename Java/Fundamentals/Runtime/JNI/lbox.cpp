#include "LegacyBox.h"

extern "C" jint BoxVolume(jint, jint, jint, jint);

JNIEXPORT jint JNICALL Java_LegacyBox_getInnerVolume(JNIEnv* env, jobject target, jint thickness)
{
	jclass cls = env->GetObjectClass(target);
	jfieldID idLength = env->GetFieldID(cls, "length", "I");
	jint length = env->GetIntField(target, idLength);
	jfieldID idBreadth = env->GetFieldID(cls, "breadth", "I");
	jint breadth = env->GetIntField(target, idBreadth);
	jfieldID idHeight = env->GetFieldID(cls, "height", "I");
	jint height = env->GetIntField(target, idHeight);
	jmethodID idValidate = env->GetMethodID(cls, "validate", "(I)Z");
	jboolean valid = env->CallBooleanMethod(target, idValidate, thickness);

	if(valid == JNI_FALSE)
	{
		jclass ex = env->FindClass("java/lang/IllegalArgumentException");
		env->ThrowNew(ex, "Invalid thickness value");
		return 0;
	}

	return BoxVolume(length, breadth, height, thickness);
}



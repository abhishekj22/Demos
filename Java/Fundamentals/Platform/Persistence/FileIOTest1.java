import java.io.*;

class FileIOTest1{

	private static void encrypt(InputStream source, OutputStream target) throws IOException{
		byte[] buffer = new byte[80];
		while(source.available() > 0){
			int n = source.read(buffer, 0, buffer.length);
			for(int i = 0; i < n; ++i)
				buffer[i] = (byte)(buffer[i] ^ '#');
			target.write(buffer, 0, n);
		}
	}

	public static void main(String[] args) throws Exception{
		FileInputStream fin = new FileInputStream(args[0]);
		FileOutputStream fout = new FileOutputStream(args[1]);
		encrypt(fin, fout);
		fout.close();
		fin.close();
	}
}


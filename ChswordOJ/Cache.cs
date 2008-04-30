using System;
using System.Text;
using System.Web;
using System.IO;

namespace ChswordOJ {
	/// <summary>
	/// �ɻû���������
	/// �޽� 2007.5
	/// </summary>
	class Cache {
		TimeSpan _TimeSpan;
		/// <summary>
		/// ���캯�����Զ����û���Ϊ1Сʱ20�֡�
		/// </summary>
		public Cache() {
			_TimeSpan = new TimeSpan(0, 1, 20, 0, 0);
		}
		/// <summary>
		/// ���캯�����ֶ����û�����Чʱ�䡣
		/// </summary>
		/// <param name="ts">������Чʱ��</param>
		public Cache(TimeSpan ts) {
			_TimeSpan = ts;
		}
		/// <summary>
		/// ��⻺���Ƿ���ڻ�Ϊ�ա�
		/// </summary>
		/// <param name="CacheName">��������</param>
		/// <returns>��������򷵻�True����֮ΪFalse��</returns>
		public Boolean IsNullorEmpty(String CacheName) {
			if (HttpContext.Current.Cache[CacheName] != null)
				if (String.IsNullOrEmpty(HttpContext.Current.Cache[CacheName].ToString()))
					return true;
				else
					return false;
			else
				return true;

		}
		/// <summary>
		/// ���û��档
		/// </summary>
		/// <param name="CacheName">��������</param>
		/// <returns>�Ƿ�洢�ɹ���</returns>
		public Boolean SetCache(String CacheName){
			try {
				String fn = HttpContext.Current.Request.MapPath(String.Format("~/Xml/{0}.xml", CacheName));
				return SetCache(CacheName,OpenTextFile(fn));
			}
			catch {
				return false;
			}
		}
		/// <summary>
		/// ���û��档
		/// </summary>
		/// <param name="CacheName">��������</param>
		/// <param name="CacheValue">�����ֵ</param>
		/// <returns>�Ƿ�洢�ɹ���</returns>
		public Boolean SetCache(String CacheName,String CacheValue) {
			try {
				if (!IsNullorEmpty(CacheName))
					return true;
				else {//��������ڣ����������뻺�档
					HttpContext.Current.Cache.Add(CacheName, CacheValue, null, DateTime.MaxValue, _TimeSpan , System.Web.Caching.CacheItemPriority.Normal, null);
					return true;
				}
			}
			catch {
				return false;
			}
		}
		/// <summary>
		/// ���ı��ļ����������ļ����ݡ�
		/// </summary>
		/// <param name="fn">�ļ�·����</param>
		/// <returns>�����ı��ļ����ݡ�</returns>
		String OpenTextFile(String fn) {
			String text;
			using (StreamReader sr = new StreamReader(fn, System.Text.Encoding.UTF8)) {
				text = sr.ReadToEnd();
			}
			return text;
		}
	}
}

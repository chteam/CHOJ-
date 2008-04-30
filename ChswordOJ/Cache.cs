using System;
using System.Text;
using System.Web;
using System.IO;

namespace ChswordOJ {
	/// <summary>
	/// 成幻互联缓存类
	/// 邹健 2007.5
	/// </summary>
	class Cache {
		TimeSpan _TimeSpan;
		/// <summary>
		/// 构造函数。自动设置缓存为1小时20分。
		/// </summary>
		public Cache() {
			_TimeSpan = new TimeSpan(0, 1, 20, 0, 0);
		}
		/// <summary>
		/// 构造函数。手动设置缓存有效时间。
		/// </summary>
		/// <param name="ts">缓存有效时间</param>
		public Cache(TimeSpan ts) {
			_TimeSpan = ts;
		}
		/// <summary>
		/// 检测缓存是否存在或为空。
		/// </summary>
		/// <param name="CacheName">缓存名称</param>
		/// <returns>缓存存在则返回True，反之为False。</returns>
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
		/// 设置缓存。
		/// </summary>
		/// <param name="CacheName">缓存名称</param>
		/// <returns>是否存储成功。</returns>
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
		/// 设置缓存。
		/// </summary>
		/// <param name="CacheName">缓存名称</param>
		/// <param name="CacheValue">缓存的值</param>
		/// <returns>是否存储成功。</returns>
		public Boolean SetCache(String CacheName,String CacheValue) {
			try {
				if (!IsNullorEmpty(CacheName))
					return true;
				else {//如果不存在，则重新载入缓存。
					HttpContext.Current.Cache.Add(CacheName, CacheValue, null, DateTime.MaxValue, _TimeSpan , System.Web.Caching.CacheItemPriority.Normal, null);
					return true;
				}
			}
			catch {
				return false;
			}
		}
		/// <summary>
		/// 打开文本文件，并返回文件内容。
		/// </summary>
		/// <param name="fn">文件路径。</param>
		/// <returns>返回文本文件内容。</returns>
		String OpenTextFile(String fn) {
			String text;
			using (StreamReader sr = new StreamReader(fn, System.Text.Encoding.UTF8)) {
				text = sr.ReadToEnd();
			}
			return text;
		}
	}
}

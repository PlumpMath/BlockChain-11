﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain {
	class Block {

		public string PrevHash { get; set; }
		public int Index { get; set; }
		public DateTime Timestamp { get; set; }
		public string Data { get; set; }
		public string Hash { get; set; }
		public int Nonce { get; set; }

		public static string CalcSHA245Hash(string message) {
			SHA256 sham256 = SHA256Managed.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(message);
			byte[] hbytes = sham256.ComputeHash(bytes);
			StringBuilder sb = new StringBuilder();
			foreach (var b in hbytes) {
				sb.Append(b.ToString("X2"));
			}
			return sb.ToString();
		}
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.Append(string.Format("PHash: {0}\n", PrevHash));
			sb.Append(String.Format("Data : {0}\n", Data));
			sb.Append(String.Format("Index: {0}\n", Index));
			sb.Append(String.Format("Stamp: {0}\n", Timestamp));
			sb.Append(String.Format("Nonce: {0}\n", Nonce));
			sb.Append(string.Format("Hash : {0}\n", Hash));
			sb.Append("+----------------------------------------------------------------------+");
			return sb.ToString();
		}
		public Block(string message) {
			this.PrevHash = "0";
			this.Index = 0;
			this.Timestamp = DateTime.Now;
			this.Data = message;
			this.Hash = "0";
			this.Nonce = 0;
		}
		public string ToHashString() {
			return $"{Index}{PrevHash}{Timestamp}{Data}{Nonce}";
		}
	}
}
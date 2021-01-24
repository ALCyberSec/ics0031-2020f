using System;

namespace KeyExchange
{
    class DHKeyExchange
    {
        private ulong _mod;
        private ulong _gen;
        private ulong _publicKey;
        private ulong _privateKey;
        private ulong _secret;
        private DHKeyExchange _otherPart;

        public ulong Secret {
            get { 
                return this._secret; 
            } 
        }
        public ulong PublicKey { 
            get { 
                return this._publicKey; 
            } 
        }
        public ulong PrivateKey { 
            get { 
                return this._privateKey; 
            } 
            
            set {
                if (value < 2) {
                    throw new System.Exception("Private key must be >= 2");
                }

                this._privateKey = value;
            } 
        }
        public ulong Gen { 
            get { 
                return this._gen; 
            } 
            
            set {
                if (value < 2) {
                    throw new System.Exception("Gen must be >= 2");
                }

                this._gen = value;
            } 
        }
        public DiffieHellman OtherPart {
            get { 
                return this._otherPart; 
            }

            set {
                if (value == null) {
                    throw new System.ArgumentNullException("OtherPart", "Other part must not be null");
                }
                
                this._otherPart = value;

                if (this.OtherPart.OtherPart == null || !this.OtherPart.OtherPart.Equals(this)) {
                    this.OtherPart.OtherPart = this;
                }

                SyncVars();
            }
        }
        public ulong Mod {
            get { 
                return this._mod; 
            }

            set {
                if (value < 2 || !IsPrime(value)) {
                    throw new System.Exception("Mod must be a prime number");
                }

                this._mod = value;
            }
        }

        public DHKeyExchange(ulong? mod = null, ulong? gen = null, ulong? privateKey = null, DHKeyExchange otherPart = null) {
            Random rand = new Random();

            this.Mod = mod;
            this.Generator = gen;
            this.PrivateKey = privateKey;

            this._publicKey = CalcPublicKey();

            if (otherPart != null) {
                this.OtherPart = otherPart;

                OtherPart.SyncVariables();

                this.CalcSecret();

                OtherPart.CalculateSharedSecret();

                bool res = false;

                if (this._secret == this.OtherPart.SharedSecret) {
                    res = true;
                }

                if (res) {
                    Console.WriteLine("OK");
                } else {
                    Console.WriteLine("NOT OK");
                }
            }
        }

        public void CalcSecret() {
            return this._secret = (ulong)(Math.Pow(this.OtherPart.PublicKey, this._privateKey) % this.Mod);
        }

        public ulong CalcPublicKey() {
            return (ulong)(Math.Pow(this.Generator, this._privateKey) % this.Mod);
        }

        public void SyncVars() {
            if (this.OtherPart == null) {
                return;
            }

            this.OtherPart.Mod = this.Mod;
            this.OtherPart.Generator = this.Generator;
        }

        private static bool IsPrime(ulong value) {
            for (ulong i = 2; i < Math.Floor(Math.Sqrt(value)); i++) {
                if (value % i == 0) {
                    return false;
                }
            }

            return true;
        }
    }
}
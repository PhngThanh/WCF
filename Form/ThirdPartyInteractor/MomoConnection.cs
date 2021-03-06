﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartyInteractor
{
    public class MomoConnection
    {
        public string ApiUrl { get; set; }
        public string PartnerCode { get; set; }
        public string PartnerPassphrase { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }

        public MomoConnection()
        {
            this.PartnerCode = "passio";
            this.PartnerPassphrase = "zaQ@123";
            this.ApiUrl = "https://payment.momo.vn:19955/api/proxy/get-trans";
            this.PublicKey = @"-----BEGIN PGP PUBLIC KEY BLOCK-----
Version: Keybase OpenPGP v1.0.0
Comment: https://keybase.io/crypto

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
DyvE6eTgVsVx0Whw0t+daV3IgqriM9COwfxrfw==
=OUlZ
-----END PGP PUBLIC KEY BLOCK-----
";
            this.PrivateKey = @"-----BEGIN PGP PRIVATE KEY BLOCK-----
Version: Keybase OpenPGP v1.0.0
Comment: https://keybase.io/crypto

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
=EfVY
-----END PGP PRIVATE KEY BLOCK-----
";
        }

        string apiUrl = "https://payment.momo.vn:19955/api/proxy/get-trans";
        string partnerCode = "passio";
        string partnerPassphrase = "zaqQ@123";
        string publicKey = "";
        string privateKey = "";
    }
}

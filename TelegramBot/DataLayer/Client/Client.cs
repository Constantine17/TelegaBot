﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Client
{
    public class Client : IClient
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Company { get; set; } = "";
        public string Position { get; set; } = "";
        public string MemberBefore { get; set; } = "";
        public string Role { get; set; } = "";
        public string RigistrationDate { get; set; } = "";

        public IEnumerator<string> GetEnumerator()
        {
            yield return FirstName;
            yield return LastName;
            yield return Company;
            yield return Position;
            yield return MemberBefore;
            yield return Role;
            yield return RigistrationDate;
        }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this;
    }
}

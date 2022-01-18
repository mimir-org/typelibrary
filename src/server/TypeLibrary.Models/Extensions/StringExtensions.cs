﻿using System;
using Mimirorg.Common.Exceptions;
using Mimirorg.Common.Extensions;

namespace TypeLibrary.Models.Extensions
{
    public static class StringExtensions
    {
        //public static (string terminalCategoryId, string terminalTypeId) CreateCategoryIdAndTerminalTypeId(this string terminalName, string terminalCategoryId)
        //{
        //    if (string.IsNullOrEmpty(terminalCategoryId) || string.IsNullOrEmpty(terminalName))
        //        throw new MimirorgNullReferenceException("Category and terminal can't be null");

        //    var category = new terminalcategory
        //    {
        //        id = terminalcategoryid
        //    };

        //    var createterminaltype = new createterminaltype
        //    {
        //        name = terminalname,
        //        terminalcategoryid = category.id
        //    };

        //    var terminaltypeid = createterminaltype.key.createmd5();

        //    return (category.id, terminaltypeid);
        //}

        public static string IncrementMajorVersion(this string version)
        {
            return IncrementVersion(version, true, false, false);
        }

        public static string IncrementMinorVersion(this string version)
        {
            return IncrementVersion(version, false, true, false);
        }

        public static string IncrementCommitVersion(this string version)
        {
            return IncrementVersion(version, false, false, true);
        }

        #region Private

        private static string IncrementVersion(string version, bool incrementMajor, bool incrementMinor, bool incrementCommit)
        {
            const int incrementStep = 1;

            if (string.IsNullOrWhiteSpace(version))
                return version;

            var versionStringSplit = version.Trim().Split(".");

            if (versionStringSplit.Length is < 2 or > 3)
                return version;

            string newVersion;
            int versionNumber;

            if (incrementMajor)
            {
                versionNumber = Convert.ToInt32(versionStringSplit[0]) + incrementStep;
                newVersion = versionNumber + ".0";
                return versionStringSplit.Length == 2 ? newVersion : newVersion + ".0";
            }

            if (incrementMinor)
            {
                versionNumber = Convert.ToInt32(versionStringSplit[1]) + incrementStep;
                newVersion = versionStringSplit[0] + "." + versionNumber;
                return versionStringSplit.Length == 2 ? newVersion : newVersion + "." + versionStringSplit[2];
            }

            if (!incrementCommit || versionStringSplit.Length != 3) 
                return version;

            versionNumber = Convert.ToInt32(versionStringSplit[2]) + incrementStep;
            newVersion = versionStringSplit[0] + "." + versionStringSplit[1] + "." + versionNumber;
            
            return newVersion;
        }

        #endregion Private
    }
}
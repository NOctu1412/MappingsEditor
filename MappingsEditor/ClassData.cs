using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MappingsEditor {
    public record class MemberData {
        public string? Name { get; init; }
        public string? ObfuscatedName { get; init; }
        public string? Descriptor { get; init; }
        public bool Static { get; init; }

        public MemberData() { }

        public MemberData(string? name, string? obfName, string? desc, bool isStatic) {
            Name = name;
            ObfuscatedName = obfName;
            Descriptor = desc;
            Static = isStatic;
        }
    }

    public class ClassData {
        public string Name { get; set; } = "";
        public string ObfuscatedName { get; set; } = "";
        public List<MemberData> Fields { get; set; } = new();
        public List<MemberData> Methods { get; set; } = new();

        public override string ToString() {
            return Name;
        }

        public static string SerializeClassDataList(List<ClassData> classDataList) {
            var filteredClassDataList = new List<object>();

            foreach (var classData in classDataList) {
                if (classData.Name == "" || classData.ObfuscatedName == "") continue;

                var filteredFields = classData.Fields.FindAll(IsMemberDataValid);
                var filteredMethods = classData.Methods.FindAll(IsMemberDataValid);

                var filteredClassData = new {
                    classData.Name,
                    classData.ObfuscatedName,
                    Fields = filteredFields,
                    Methods = filteredMethods
                };

                filteredClassDataList.Add(filteredClassData);
            }

            var options = new JsonSerializerOptions {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Serialize(filteredClassDataList, options);
        }

        private static bool IsMemberDataValid(MemberData member) {
            return !string.IsNullOrEmpty(member.Name) &&
                   !string.IsNullOrEmpty(member.ObfuscatedName) &&
                   !string.IsNullOrEmpty(member.Descriptor);
        }

        public static List<ClassData> DeserializeClassDataList(string json) {
            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            };

            var classDataList = JsonSerializer.Deserialize<List<ClassData>>(json, options) ?? new List<ClassData>();

            foreach (var classData in classDataList) {
                classData.Fields = classData.Fields.FindAll(IsMemberDataValid);
                classData.Methods = classData.Methods.FindAll(IsMemberDataValid);
            }

            return classDataList;
        }
    }
}

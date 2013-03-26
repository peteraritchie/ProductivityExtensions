using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	public static class Reflectable
	{
		/// <summary>
		/// Makes Attribute.GetCustomAttribute() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = assembly.GetCustomAttribute&lt;AssemblyCopyrightAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static T GetCustomAttribute<T>(this Assembly source) where T: Attribute
		{
			if (source == null) throw new ArgumentNullException("source");
			return (T)Attribute.GetCustomAttribute(source, typeof(T));
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttribute() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = memberInfo.GetCustomAttribute&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static T GetCustomAttribute<T>(this MemberInfo source) where T : Attribute
		{
			return (T) Attribute.GetCustomAttribute(source, typeof (T));
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttribute() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = parameterInfo.GetCustomAttribute&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static T GetCustomAttribute<T>(this ParameterInfo source) where T : Attribute
		{
			return (T)Attribute.GetCustomAttribute(source, typeof(T));
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttribute() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = module.GetCustomAttribute&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"> </param>
		/// <returns></returns>
		public static T GetCustomAttribute<T>(this Module source) where T : Attribute
		{
			return (T)Attribute.GetCustomAttribute(source, typeof(T));
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttribute() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = assembly.GetCustomAttribute&lt;AssemblyCopyrightAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <param name="inherit">If true, specifies to also search the ancestors of <paramref name="source" /> for custom attributes. </param>
		/// <returns></returns>
		public static T GetCustomAttribute<T>(this Assembly source, bool inherit) where T : Attribute
		{
			if (source == null) throw new ArgumentNullException("source");
			return (T)Attribute.GetCustomAttribute(source, typeof(T), inherit);
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttribute() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = memberInfo.GetCustomAttribute&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <param name="inherit">If true, specifies to also search the ancestors of <paramref name="source" /> for custom attributes. </param>
		/// <returns></returns>
		public static T GetCustomAttribute<T>(this MemberInfo source, bool inherit) where T : Attribute
		{
			return (T)Attribute.GetCustomAttribute(source, typeof(T), inherit);
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttribute() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = parameterInfo.GetCustomAttribute&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <param name="inherit">If true, specifies to also search the ancestors of <paramref name="source" /> for custom attributes. </param>
		/// <returns></returns>
		public static T GetCustomAttribute<T>(this ParameterInfo source, bool inherit) where T : Attribute
		{
			return (T)Attribute.GetCustomAttribute(source, typeof(T), inherit);
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttribute() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = module.GetCustomAttribute&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"> </param>
		/// <param name="inherit">If true, specifies to also search the ancestors of <paramref name="source" /> for custom attributes. </param>
		/// <returns>A reference to the single custom attribute of type <typeparamref name="T"/> that is applied to <paramref name="source" />, or null if there is no such attribute.</returns>
		public static T GetCustomAttribute<T>(this Module source, bool inherit) where T : Attribute
		{
			return (T)Attribute.GetCustomAttribute(source, typeof(T), inherit);
		}
//
		/// <summary>
		/// Makes Attribute.GetCustomAttributes() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = assembly.GetCustomAttributes&lt;AssemblyCopyrightAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static T[] GetCustomAttributes<T>(this Assembly source) where T : Attribute
		{
			if (source == null) throw new ArgumentNullException("source");
			return (T[])Attribute.GetCustomAttributes(source, typeof(T));
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttributes() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = memberInfo.GetCustomAttributes&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static T[] GetCustomAttributes<T>(this MemberInfo source) where T : Attribute
		{
			return (T[])Attribute.GetCustomAttributes(source, typeof(T));
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttributes() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = parameterInfo.GetCustomAttributes&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static T[] GetCustomAttributes<T>(this ParameterInfo source) where T : Attribute
		{
			return (T[])Attribute.GetCustomAttributes(source, typeof(T));
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttributes() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = module.GetCustomAttributes&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"> </param>
		/// <returns></returns>
		public static T[] GetCustomAttributes<T>(this Module source) where T : Attribute
		{
			return (T[])Attribute.GetCustomAttributes(source, typeof(T));
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttributes() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = assembly.GetCustomAttributes&lt;AssemblyCopyrightAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <param name="inherit">If true, specifies to also search the ancestors of <paramref name="source" /> for custom attributes. </param>
		/// <returns></returns>
		public static T[] GetCustomAttributes<T>(this Assembly source, bool inherit) where T : Attribute
		{
			if (source == null) throw new ArgumentNullException("source");
			return (T[])Attribute.GetCustomAttributes(source, typeof(T), inherit);
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttributes() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = memberInfo.GetCustomAttributes&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <param name="inherit">If true, specifies to also search the ancestors of <paramref name="source" /> for custom attributes. </param>
		/// <returns></returns>
		public static T[] GetCustomAttributes<T>(this MemberInfo source, bool inherit) where T : Attribute
		{
			return (T[])Attribute.GetCustomAttributes(source, typeof(T), inherit);
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttributes() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = parameterInfo.GetCustomAttributes&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"></param>
		/// <param name="inherit">If true, specifies to also search the ancestors of <paramref name="source" /> for custom attributes. </param>
		/// <returns></returns>
		public static T[] GetCustomAttributes<T>(this ParameterInfo source, bool inherit) where T : Attribute
		{
			return (T[])Attribute.GetCustomAttributes(source, typeof(T), inherit);
		}

		/// <summary>
		/// Makes Attribute.GetCustomAttributes() generic and avoids having to pass a Type and cast the result.
		/// <example>
		/// SerializableAttribute attr = module.GetCustomAttributes&lt;SerializableAttribute&gt;();
		/// </example>
		/// </summary>
		/// <typeparam name="T">The type, or a base type, of the custom attribute to search for.</typeparam>
		/// <param name="source"> </param>
		/// <param name="inherit">If true, specifies to also search the ancestors of <paramref name="source" /> for custom attributes. </param>
		/// <returns>A reference to the single custom attribute of type <typeparamref name="T"/> that is applied to <paramref name="source" />, or null if there is no such attribute.</returns>
		public static T[] GetCustomAttributes<T>(this Module source, bool inherit) where T : Attribute
		{
			return (T[])Attribute.GetCustomAttributes(source, typeof(T), inherit);
		}

		private static readonly OpCode[] singleByteOpCodes = new OpCode[0x100];
		private static readonly OpCode[] multiByteOpCodes = new OpCode[0x100];

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
		static Reflectable()
		{
			LoadOpCodes();
		}

		private static void LoadOpCodes()
		{
			foreach (FieldInfo field in typeof(OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				if (field.FieldType != typeof(OpCode))
				{
					continue;
				}
				ushort opCodeValue = (ushort)((OpCode)field.GetValue(null)).Value;
				if (opCodeValue < 0x100)
				{
					singleByteOpCodes[opCodeValue] = (OpCode)field.GetValue(null);
				}
				else
				{
					if ((opCodeValue & 0xff00) != 0xfe00)
					{
						throw new InvalidOperationException("Invalid OpCode loading opcode.");
					}
					multiByteOpCodes[opCodeValue & 0xff] = (OpCode)field.GetValue(null);
				}
			}
		}

		/// <summary>
		/// Gets a collection of <seealso cref="IlInstruction"/> representing the instructions in the body of a method
		/// </summary>
		/// <param name="methodInfo"></param>
		/// <param name="module"></param>
		/// <param name="il"></param>
		/// <returns></returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Replacing case statements would be more complex"),
		System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "only way to know if tokey not support is to catch all exceptions")]
		private static IEnumerable<IlInstruction> GetMethodInstructions(MethodInfo methodInfo, Module module, byte[] il)
		{
			int position = 0;
			List<IlInstruction> instructions = new List<IlInstruction>();
			while (position < il.Length)
			{
				OpCode code;
				ushort value = il[position++];
				if (value != 0xfe)
				{
					code = singleByteOpCodes[value];
				}
				else
				{
					value = il[position++];
					code = multiByteOpCodes[value];
					value = (ushort)(value | 0xfe00);
				}
				IlInstruction instruction = new IlInstruction(code) {Code = code};
				int metadataToken = 0;
				// get the operand of the current operation

				switch (code.OperandType)
				{
					case OperandType.InlineBrTarget:
						metadataToken = BitConverter.ToInt32(il, position);
						position += 4;
						metadataToken += position;
						instruction.Operand = metadataToken;
						break;
					case OperandType.InlineField:
						metadataToken = BitConverter.ToInt32(il, position);
						position += 4;
						try
						{
							instruction.Operand = module.ResolveField(metadataToken);
						}
						catch (Exception)
						{
						}
						break;
					case OperandType.InlineMethod:
						metadataToken = BitConverter.ToInt32(il, position);
						position += 4;
						try
						{
							instruction.Operand = module.ResolveMethod(metadataToken);
						}
						catch (Exception)
						{
						}
						if (instruction.Operand == null)
						{
							try
							{
								instruction.Operand = module.ResolveMember(metadataToken);
							}
							catch (Exception)
							{
							}
						}
						break;
					case OperandType.InlineSig:
						metadataToken = BitConverter.ToInt32(il, position);
						position += 4;
						instruction.Operand = module.ResolveSignature(metadataToken);
						break;
					case OperandType.InlineTok:
						metadataToken = BitConverter.ToInt32(il, position);
						position += 4;
						try
						{
							instruction.Operand = module.ResolveType(metadataToken);
						}
						catch
						{
						}
						// SSS : see what to do here
						break;
					case OperandType.InlineType:
						metadataToken = BitConverter.ToInt32(il, position);
						position += 4;
						// now we call the ResolveType always using the generic attributes type in order
						// to support decompilation of generic methods and classes

						// thanks to the guys from code project who commented on this missing feature

						try
						{
							if (methodInfo.DeclaringType != null)
								instruction.Operand = module.ResolveType(metadataToken, methodInfo.DeclaringType.GetGenericArguments(),
								                                         methodInfo.GetGenericArguments());
						}
						catch (Exception)
						{
						}
						break;
					case OperandType.InlineI:
						{
							instruction.Operand = BitConverter.ToInt32(il, position);
							position += 4;
							break;
						}
					case OperandType.InlineI8:
						{
							instruction.Operand = BitConverter.ToInt64(il, position);
							position += 8;
							break;
						}
					case OperandType.InlineNone:
						{
							instruction.Operand = null;
							break;
						}
					case OperandType.InlineR:
						{
							instruction.Operand = BitConverter.ToDouble(il, position);
							position += sizeof(Double);
							break;
						}
					case OperandType.InlineString:
						{
							metadataToken = BitConverter.ToInt32(il, position);
							position += 4;
							instruction.Operand = module.ResolveString(metadataToken);
							break;
						}
					case OperandType.InlineSwitch:
						{
							int count = BitConverter.ToInt32(il, position);
							position += 4;
							int[] casesAddresses = new int[count];
							for (int i = 0; i < count; i++)
							{
								casesAddresses[i] = BitConverter.ToInt32(il, position);
								position += 4;
							}
							int[] cases = new int[count];
							for (int i = 0; i < count; i++)
							{
								cases[i] = position + casesAddresses[i];
							}
							break;
						}
					case OperandType.InlineVar:
						{
							instruction.Operand = BitConverter.ToUInt16(il, position);
							position += sizeof(UInt16);
							break;
						}
					case OperandType.ShortInlineBrTarget:
						{
							instruction.Operand = (sbyte)il[position] + position;
							position++;
							break;
						}
					case OperandType.ShortInlineI:
						{
							instruction.Operand = (sbyte)il[position];
							position++;
							break;
						}
					case OperandType.ShortInlineR:
						{
							instruction.Operand = BitConverter.ToSingle(il, position);
							position += sizeof(Single);
							break;
						}
					case OperandType.ShortInlineVar:
						{
							instruction.Operand = il[position];
							position++;
							break;
						}
					default:
						{
							throw new ArgumentException(string.Format("Unknown operand type {0} in supplied IL", code.OperandType), "il");
						}
				}
				instructions.Add(instruction);
			}
			return instructions;
		}

		/// <summary>
		/// Tests wheter <paramref name="sourceType"/> references a method
		/// <example>TODO: Example for AssemblyExtensions.ReferencesMethod</example>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sourceType"></param>
		/// <param name="func"></param>
		/// <returns><code>true</code>if method contained in expression <paramref name="func"/> references any constructors in this <see cref="Type"/></returns>
		public static bool ReferencesMethod<T>(this Type sourceType, Expression<Action<T>> func)
		{
			if (sourceType == null) throw new ArgumentNullException("sourceType");
			if (func == null) throw new ArgumentNullException("func");
			var methodCallExpression = func.Body as MethodCallExpression;
			if (methodCallExpression == null) return false;
			MethodInfo memberInfo = methodCallExpression.Method;
			MethodInfo getTypeMethodInfo = typeof (Object).GetMethods().Single(x => x.Name == "GetType");// && x.GetParameters().Count() == 0 && x.ReflectedType == typeof(Object));
			bool getTypeCall = memberInfo == getTypeMethodInfo;

			foreach (var methodInfo in sourceType.GetMethods())
			{
				var methodBody = methodInfo.GetMethodBody();
				if (methodBody == null) continue;

				var il = methodBody.GetILAsByteArray();
				IEnumerable<IlInstruction> instructions = GetMethodInstructions(methodInfo, sourceType.Module, il);

				for(int i = 0; i < instructions.Count(); ++i)
				{
					var instruction = instructions.ElementAt(i);
					if(getTypeCall && instruction.Code == OpCodes.Ldtoken && i < instructions.Count() && instructions.ElementAt(i+1).Code == OpCodes.Call)
					{
						var calledMethodInfo = instructions.ElementAt(i+1).Operand as MethodInfo;
						if (calledMethodInfo == null) continue;
						if (calledMethodInfo == typeof(Type).GetMethods().Single(x => x.Name == "GetTypeFromHandle"))
							return true;
					}

					if (instruction.Code == OpCodes.Call || instruction.Code == OpCodes.Callvirt)
					{
						var calledMethodInfo = instruction.Operand as MethodInfo;
						if (calledMethodInfo == null) continue;
						if (calledMethodInfo == memberInfo) return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Tests wheter <paramref name="sourceType"/> references a constructor in <paramref name="type"/>
		/// <example>TODO: Example for AssemblyExtensions.ReferencesConstructor</example>
		/// </summary>
		/// <param name="sourceType"></param>
		/// <param name="type"> </param>
		/// <returns><code>true</code>if <paramref name="type"/> references any constructors in this <see cref="Type"/>.</returns>
		public static bool ReferencesConstructor(this Type sourceType, Type type)
		{
			if (sourceType == null) throw new ArgumentNullException("sourceType");
			return (from methodInfo in sourceType.GetMethods()
			        let methodBody = methodInfo.GetMethodBody()
			        where methodBody != null
			        let il = methodBody.GetILAsByteArray()
			        from instruction in GetMethodInstructions(methodInfo, sourceType.Module, il)
			        where instruction.Code == OpCodes.Newobj
			        select instruction.Operand).OfType<ConstructorInfo>().Any(
			        	constructorInfo => constructorInfo.DeclaringType == type);
		}

		/// <summary>
		/// Tests wheter <paramref name="sourceType"/> references a constructor in <paramref name="type"/>
		/// <example>TODO: Example for AssemblyExtensions.ReferencesConstructor</example>
		/// </summary>
		/// <param name="sourceType"></param>
		/// <returns><code>true</code>if <typeparamref name="T"/> references any constructors in this <see cref="Type"/>.</returns>
		public static bool ReferencesConstructor<T>(this Type sourceType)
		{
			return ReferencesConstructor(sourceType, typeof (T));
		}

		/// <summary>
		/// Tests where any types in the assembly references the constructor of <paramref name="type"/>
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="type"></param>
		/// <returns><code>true</code>if <paramref name="type"/> references any constructors in this <see cref="Assembly"/></returns>
		public static bool ReferencesConstructor(this Assembly assembly, Type type)
		{
			if (assembly == null) throw new ArgumentNullException("assembly");

			return assembly.GetModules().SelectMany(module => module.GetTypes()).Any(moduleType => ReferencesConstructor(moduleType, type));
		}

		/// <summary>
		/// Tests where any types in the assembly references the constructor of <paramref name="type"/>
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns><code>true</code>if <typeparamref name="T"/> references any constructors in this <see cref="Assembly"/></returns>
		public static bool ReferencesConstructor<T>(this Assembly assembly)
		{
			return ReferencesConstructor(assembly, typeof (T));
		}

		/// <summary>
		/// Gets a private field value
		/// </summary>
		/// <typeparam name="T">The type of the property</typeparam>
		/// <param name="obj">the object that will be operated upon.</param>
		/// <param name="fieldName">Name of the field whose value to retrieve.</param>
		/// <returns>The value of the property</returns>
		public static T GetPrivateFieldValue<T>(this Object obj, string fieldName)
		{
			if (obj == null) throw new ArgumentNullException("obj");
			if (string.IsNullOrWhiteSpace(fieldName)) throw new ArgumentNullException("fieldName");
			var type = obj.GetType();
			FieldInfo field;
			do
			{
				field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
				type = type.BaseType;
			} while (field == null && type != null);
			if (field == null)
				throw new InvalidOperationException(string.Format("{0} not found in type {1}", fieldName, type.FullName));
			if (!typeof(T).IsAssignableFrom(field.FieldType))
				throw
					new InvalidOperationException(string.Format("{0} is not assignable from {1}", typeof(T).FullName,
																field.FieldType.FullName));
			return (T)field.GetValue(obj);
		}

		/// <summary>
		/// Gets a private property value
		/// </summary>
		/// <typeparam name="T">The type of the field</typeparam>
		/// <param name="obj">the object that will be operated upon.</param>
		/// <param name="propertyName">Name of the field whose value to retrieve.</param>
		/// <returns>The value of the field</returns>
		public static T GetPrivatePropertyValue<T>(this Object obj, string propertyName)
		{
			if (obj == null) throw new ArgumentNullException("obj");
			if (string.IsNullOrWhiteSpace(propertyName)) throw new ArgumentNullException("propertyName");
			var type = obj.GetType();
			PropertyInfo property;
			do
			{
				property = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
				type = type.BaseType;
			} while (property == null && type != null);
			if (property == null)
				throw new InvalidOperationException(string.Format("{0} not found in type {1}", propertyName, type.FullName));
			if (!typeof(T).IsAssignableFrom(property.PropertyType))
				throw
					new InvalidOperationException(string.Format("{0} is not assignable from {1}", typeof(T).FullName,
																property.PropertyType.FullName));
			return (T)property.GetValue(obj, null);
		}

		/// <summary>
		/// Gets a private field value
		/// </summary>
		/// <typeparam name="T">The type of the property</typeparam>
		/// <param name="obj">the object that will be operated upon.</param>
		/// <param name="fieldName">Name of the field whose value to retrieve.</param>
		/// <returns>The value of the property</returns>
		/// <param name="value">The value used to set the field</param>
		public static void SetPrivateFieldValue<T>(this Object obj, string fieldName, T value)
		{
			if (obj == null) throw new ArgumentNullException("obj");
			if (string.IsNullOrWhiteSpace(fieldName)) throw new ArgumentNullException("fieldName");
			var type = obj.GetType();
			FieldInfo field;
			do
			{
				field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
				type = type.BaseType;
			} while (field == null && type != null);
			if (field == null)
				throw new InvalidOperationException(string.Format("{0} not found in type {1}", fieldName, type.FullName));
			if (!typeof(T).IsAssignableFrom(field.FieldType))
				throw
					new InvalidOperationException(string.Format("{0} is not assignable from {1}", typeof(T).FullName,
																field.FieldType.FullName));
			field.SetValue(obj, value);
		}

		/// <summary>
		/// Sets a private property value
		/// </summary>
		/// <typeparam name="T">The type of the field</typeparam>
		/// <param name="obj">the object that will be operated upon.</param>
		/// <param name="propertyName">Name of the field whose value to retrieve.</param>
		/// <param name="value">The value used to set the property</param>
		public static void SetPrivatePropertyValue<T>(this Object obj, string propertyName, T value)
		{
			if (obj == null) throw new ArgumentNullException("obj");
			if (string.IsNullOrWhiteSpace(propertyName)) throw new ArgumentNullException("propertyName");
			var type = obj.GetType();
			PropertyInfo property;
			do
			{
				property = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
				type = type.BaseType;
			} while (property == null && type != null);
			if (property == null)
				throw new InvalidOperationException(string.Format("{0} not found in type {1}", propertyName, type.FullName));
			if (!typeof(T).IsAssignableFrom(property.PropertyType))
				throw
					new InvalidOperationException(string.Format("{0} is not assignable from {1}", typeof(T).FullName,
																property.PropertyType.FullName));
			property.SetValue(obj, value, null);
		}
	}
}
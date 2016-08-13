using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EntityProvider
{
	class EntityProvider
	{
		private EntityFactory entity;
		private List<Entity> entityPool = new  List<Entity>();
		private GameObject game;
		private String[] list;
		private Tokeniser tokeniser = new Tokeniser();
		private FileReader reader = new FileReader();
		private List<String>  listRead;
		public String[] getEntity
		
		public void generateEntities(String fileName)
		{
			listRead = reader.getLines(fileName);
			
			foreach(String line in listRead)
			{
				list = tokeniser.tokenise(line);
				game = entity.build(list);
				Entity parent = getEntityParent(list[2]);
				Entity newEntity = new Entity();
				newEntity.setName(list[1]);
				newEntity.setGameObject(game);
				newEntity.setParent(parent);
				entityPool.add(newEntity);
				
				
			}
			
		}
		
		public Entity[] getEntityPool()
		{
			return this.entityPool;
		}
		
		public Entity getEntityParent(String name)
		{
			if(name =="null")
			{
				return null;
			}
			else if(entityPool.Exists(x => x.getName() == name))
			{
				return entityPool.Find(x => x.getName() == name);
			}
			else
			{
				throw new System.ArgumentException("Parent does not exist");
			}
		}
	}
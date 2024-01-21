﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorBlog.Data.Models;

/// <summary>
///   Class for storing data for a blog post.
/// </summary>
[Serializable]
public class BlogPost
{
	/// <summary>
	///   Gets or sets the ID of the blog post.
	/// </summary>
	[BsonId]
	[BsonElement("_id")]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the URL of the blog post.
	/// </summary>
	[BsonRepresentation(BsonType.String)]
	public string Url { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the title of the blog post.
	/// </summary>
	[BsonRepresentation(BsonType.String)]
	public string Title { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the content of the blog post.
	/// </summary>
	[BsonRepresentation(BsonType.String)]
	public string Content { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the date the blog post was created.
	/// </summary>
	[BsonRepresentation(BsonType.DateTime)]
	public DateTime Created { get; set; } = DateTime.Now;

	/// <summary>
	///   Gets or sets the date the blog post was updated.
	/// </summary>
	[BsonRepresentation(BsonType.DateTime)]
	public DateTime? Updated { get; set; }

	/// <summary>
	///   Gets or sets the name of the author of the blog post.
	/// </summary>
	public BasicUser Author { get; set; } = new();

	/// <summary>
	///   Gets or sets the description for the blog post.
	/// </summary>
	[BsonRepresentation(BsonType.String)]
	public string Description { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the image associated with the blog post.
	/// </summary>
	[BsonRepresentation(BsonType.String)]
	public string Image { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets a value indicating whether the blog post is published.
	/// </summary>
	[BsonRepresentation(BsonType.Boolean)]
	public bool IsPublished { get; set; } = true;

	/// <summary>
	///   Gets or sets a value indicating whether the blog post has been deleted.
	/// </summary>
	[BsonRepresentation(BsonType.Boolean)]
	public bool IsArchived { get; set; }

	/// <summary>
	///   Gets or sets who archived the record.
	/// </summary>
	/// <value>
	///   Who archived the record.
	/// </value>
	public BasicUser ArchivedBy { get; set; } = new();
}
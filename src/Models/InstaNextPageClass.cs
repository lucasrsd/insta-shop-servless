// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
using System.Collections.Generic;

namespace InstaShop.HastTags.Models.InstaNextPageClass
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class PageInfo
    {
        public bool has_next_page { get; set; }
        public string end_cursor { get; set; }
    }

    public class Dimensions
    {
        public int height { get; set; }
        public int width { get; set; }
    }

    public class DisplayResource
    {
        public string src { get; set; }
        public int config_width { get; set; }
        public int config_height { get; set; }
    }

    public class EdgeMediaToTaggedUser
    {
        public List<object> edges { get; set; }
    }

    public class Node2
    {
        public string text { get; set; }
    }

    public class Edge2
    {
        public Node2 node { get; set; }
    }

    public class EdgeMediaToCaption
    {
        public List<Edge2> edges { get; set; }
    }

    public class PageInfo2
    {
        public bool has_next_page { get; set; }
        public object end_cursor { get; set; }
    }

    public class Owner
    {
        public string id { get; set; }
        public bool is_verified { get; set; }
        public string profile_pic_url { get; set; }
        public string username { get; set; }
    }

    public class Node3
    {
        public string id { get; set; }
        public string text { get; set; }
        public int created_at { get; set; }
        public bool did_report_as_spam { get; set; }
        public Owner owner { get; set; }
        public bool viewer_has_liked { get; set; }
    }

    public class Edge3
    {
        public Node3 node { get; set; }
    }

    public class EdgeMediaToComment
    {
        public int count { get; set; }
        public PageInfo2 page_info { get; set; }
        public List<Edge3> edges { get; set; }
    }

    public class EdgeMediaToSponsorUser
    {
        public List<object> edges { get; set; }
    }

    public class EdgeMediaPreviewLike
    {
        public int count { get; set; }
        public List<object> edges { get; set; }
    }

    public class Owner2
    {
        public string id { get; set; }
        public string username { get; set; }
    }

    public class ThumbnailResource
    {
        public string src { get; set; }
        public int config_width { get; set; }
        public int config_height { get; set; }
    }

    public class Dimensions2
    {
        public int height { get; set; }
        public int width { get; set; }
    }

    public class DisplayResource2
    {
        public string src { get; set; }
        public int config_width { get; set; }
        public int config_height { get; set; }
    }

    public class EdgeMediaToTaggedUser2
    {
        public List<object> edges { get; set; }
    }

    public class Node4
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public object gating_info { get; set; }
        public object fact_check_overall_rating { get; set; }
        public object fact_check_information { get; set; }
        public object media_overlay_info { get; set; }
        public object sensitivity_friction_info { get; set; }
        public Dimensions2 dimensions { get; set; }
        public string display_url { get; set; }
        public List<DisplayResource2> display_resources { get; set; }
        public bool is_video { get; set; }
        public string media_preview { get; set; }
        public string tracking_token { get; set; }
        public EdgeMediaToTaggedUser2 edge_media_to_tagged_user { get; set; }
        public object accessibility_caption { get; set; }
    }

    public class Edge4
    {
        public Node4 node { get; set; }
    }

    public class EdgeSidecarToChildren
    {
        public List<Edge4> edges { get; set; }
    }

    public class Node
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public object gating_info { get; set; }
        public object fact_check_overall_rating { get; set; }
        public object fact_check_information { get; set; }
        public object media_overlay_info { get; set; }
        public object sensitivity_friction_info { get; set; }
        public Dimensions dimensions { get; set; }
        public string display_url { get; set; }
        public List<DisplayResource> display_resources { get; set; }
        public bool is_video { get; set; }
        public string media_preview { get; set; }
        public string tracking_token { get; set; }
        public EdgeMediaToTaggedUser edge_media_to_tagged_user { get; set; }
        public object accessibility_caption { get; set; }
        public EdgeMediaToCaption edge_media_to_caption { get; set; }
        public string shortcode { get; set; }
        public EdgeMediaToComment edge_media_to_comment { get; set; }
        public EdgeMediaToSponsorUser edge_media_to_sponsor_user { get; set; }
        public bool comments_disabled { get; set; }
        public int taken_at_timestamp { get; set; }
        public EdgeMediaPreviewLike edge_media_preview_like { get; set; }
        public Owner2 owner { get; set; }
        public object location { get; set; }
        public bool viewer_has_liked { get; set; }
        public bool viewer_has_saved { get; set; }
        public bool viewer_has_saved_to_collection { get; set; }
        public bool viewer_in_photo_of_you { get; set; }
        public bool viewer_can_reshare { get; set; }
        public string thumbnail_src { get; set; }
        public List<ThumbnailResource> thumbnail_resources { get; set; }
        public EdgeSidecarToChildren edge_sidecar_to_children { get; set; }
    }

    public class Edge
    {
        public Node node { get; set; }
    }

    public class EdgeOwnerToTimelineMedia
    {
        public int count { get; set; }
        public PageInfo page_info { get; set; }
        public List<Edge> edges { get; set; }
    }

    public class User
    {
        public EdgeOwnerToTimelineMedia edge_owner_to_timeline_media { get; set; }
    }

    public class Data
    {
        public User user { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
        public string status { get; set; }
    }


}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
using System.Collections.Generic;

namespace InstaShop.HastTags.Models.PostClass
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
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

    public class Node
    {
        public string text { get; set; }
    }

    public class Edge
    {
        public Node node { get; set; }
    }

    public class EdgeMediaToCaption
    {
        public List<Edge> edges { get; set; }
    }

    public class PageInfo
    {
        public bool has_next_page { get; set; }
        public object end_cursor { get; set; }
    }

    public class EdgeMediaToParentComment
    {
        public int count { get; set; }
        public PageInfo page_info { get; set; }
        public List<object> edges { get; set; }
    }

    public class EdgeMediaToHoistedComment
    {
        public List<object> edges { get; set; }
    }

    public class EdgeMediaPreviewComment
    {
        public int count { get; set; }
        public List<object> edges { get; set; }
    }

    public class EdgeMediaPreviewLike
    {
        public int count { get; set; }
        public List<object> edges { get; set; }
    }

    public class EdgeMediaToSponsorUser
    {
        public List<object> edges { get; set; }
    }

    public class Location
    {
        public string id { get; set; }
        public bool has_public_page { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public object address_json { get; set; }
    }

    public class EdgeOwnerToTimelineMedia
    {
        public int count { get; set; }
    }

    public class EdgeFollowedBy
    {
        public int count { get; set; }
    }

    public class Owner
    {
        public string id { get; set; }
        public bool is_verified { get; set; }
        public string profile_pic_url { get; set; }
        public string username { get; set; }
        public bool blocked_by_viewer { get; set; }
        public bool restricted_by_viewer { get; set; }
        public bool followed_by_viewer { get; set; }
        public string full_name { get; set; }
        public bool has_blocked_viewer { get; set; }
        public bool is_private { get; set; }
        public bool is_unpublished { get; set; }
        public bool requested_by_viewer { get; set; }
        public bool pass_tiering_recommendation { get; set; }
        public EdgeOwnerToTimelineMedia edge_owner_to_timeline_media { get; set; }
        public EdgeFollowedBy edge_followed_by { get; set; }
    }

    public class EdgeWebMediaToRelatedMedia
    {
        public List<object> edges { get; set; }
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

    public class Node2
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public string shortcode { get; set; }
        public Dimensions2 dimensions { get; set; }
        public object gating_info { get; set; }
        public object fact_check_overall_rating { get; set; }
        public object fact_check_information { get; set; }
        public object sensitivity_friction_info { get; set; }
        public object media_overlay_info { get; set; }
        public string media_preview { get; set; }
        public string display_url { get; set; }
        public List<DisplayResource2> display_resources { get; set; }
        public string accessibility_caption { get; set; }
        public bool is_video { get; set; }
        public string tracking_token { get; set; }
        public EdgeMediaToTaggedUser2 edge_media_to_tagged_user { get; set; }
    }

    public class Edge2
    {
        public Node2 node { get; set; }
    }

    public class EdgeSidecarToChildren
    {
        public List<Edge2> edges { get; set; }
    }

    public class EdgeRelatedProfiles
    {
        public List<object> edges { get; set; }
    }

    public class ShortcodeMedia
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public string shortcode { get; set; }
        public Dimensions dimensions { get; set; }
        public object gating_info { get; set; }
        public object fact_check_overall_rating { get; set; }
        public object fact_check_information { get; set; }
        public object sensitivity_friction_info { get; set; }
        public object media_overlay_info { get; set; }
        public object media_preview { get; set; }
        public string display_url { get; set; }
        public List<DisplayResource> display_resources { get; set; }
        public bool is_video { get; set; }
        public string tracking_token { get; set; }
        public EdgeMediaToTaggedUser edge_media_to_tagged_user { get; set; }
        public EdgeMediaToCaption edge_media_to_caption { get; set; }
        public bool caption_is_edited { get; set; }
        public bool has_ranked_comments { get; set; }
        public EdgeMediaToParentComment edge_media_to_parent_comment { get; set; }
        public EdgeMediaToHoistedComment edge_media_to_hoisted_comment { get; set; }
        public EdgeMediaPreviewComment edge_media_preview_comment { get; set; }
        public bool comments_disabled { get; set; }
        public bool commenting_disabled_for_viewer { get; set; }
        public int taken_at_timestamp { get; set; }
        public EdgeMediaPreviewLike edge_media_preview_like { get; set; }
        public EdgeMediaToSponsorUser edge_media_to_sponsor_user { get; set; }
        public Location location { get; set; }
        public bool viewer_has_liked { get; set; }
        public bool viewer_has_saved { get; set; }
        public bool viewer_has_saved_to_collection { get; set; }
        public bool viewer_in_photo_of_you { get; set; }
        public bool viewer_can_reshare { get; set; }
        public Owner owner { get; set; }
        public bool is_ad { get; set; }
        public EdgeWebMediaToRelatedMedia edge_web_media_to_related_media { get; set; }
        public EdgeSidecarToChildren edge_sidecar_to_children { get; set; }
        public EdgeRelatedProfiles edge_related_profiles { get; set; }
    }

    public class Graphql
    {
        public ShortcodeMedia shortcode_media { get; set; }
    }

    public class Root
    {
        public Graphql graphql { get; set; }
    }


}

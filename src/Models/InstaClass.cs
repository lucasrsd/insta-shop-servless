// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
using System.Collections.Generic;

namespace InstaShop.HastTags.Models.InstaClass
{
    public class Config
    {
        public string csrf_token { get; set; }
        public object viewer { get; set; }
        public object viewerId { get; set; }
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

    public class User
    {
        public string full_name { get; set; }
        public string id { get; set; }
        public bool is_verified { get; set; }
        public string profile_pic_url { get; set; }
        public string username { get; set; }
    }

    public class Node
    {
        public User user { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }

    public class Edge
    {
        public Node node { get; set; }
    }

    public class EdgeMediaToTaggedUser
    {
        public List<Edge> edges { get; set; }
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
        public string address_json { get; set; }
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
        public object restricted_by_viewer { get; set; }
        public bool followed_by_viewer { get; set; }
        public string full_name { get; set; }
        public bool has_blocked_viewer { get; set; }
        public bool is_private { get; set; }
        public bool is_unpublished { get; set; }
        public bool requested_by_viewer { get; set; }
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

    public class User2
    {
        public string full_name { get; set; }
        public string id { get; set; }
        public bool is_verified { get; set; }
        public string profile_pic_url { get; set; }
        public string username { get; set; }
    }

    public class Node4
    {
        public User2 user { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }

    public class Edge4
    {
        public Node4 node { get; set; }
    }

    public class EdgeMediaToTaggedUser2
    {
        public List<Edge4> edges { get; set; }
    }

    public class Node3
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

    public class Edge3
    {
        public Node3 node { get; set; }
    }

    public class EdgeSidecarToChildren
    {
        public List<Edge3> edges { get; set; }
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

    public class PostPage
    {
        public Graphql graphql { get; set; }
    }

    public class EntryData
    {
        public List<PostPage> PostPage { get; set; }
    }

    public class ZeroData
    {
    }

    public class ServerChecks
    {
    }

    // public class Knobx    {
    //     public bool 17 { get; set; } 
    //     public bool 20 { get; set; } 
    //     public bool 22 { get; set; } 
    //     public bool 23 { get; set; } 
    //     public bool 24 { get; set; } 
    //     public bool 25 { get; set; } 
    //     public bool 26 { get; set; } 
    //     public bool 27 { get; set; } 
    //     public bool 28 { get; set; } 
    //     public bool 29 { get; set; } 
    //     public bool 30 { get; set; } 
    //     public bool 31 { get; set; } 
    //     public bool 32 { get; set; } 
    //     public bool 34 { get; set; } 
    //     public bool 35 { get; set; } 
    //     public bool 36 { get; set; } 
    //     public bool 37 { get; set; } 
    //     public bool 4 { get; set; } 
    // }

    public class Gatekeepers
    {
        // public bool 10 { get; set; } 
        // public bool 100 { get; set; } 
        // public bool 101 { get; set; } 
        // public bool 102 { get; set; } 
        // public bool 103 { get; set; } 
        // public bool 104 { get; set; } 
        // public bool 105 { get; set; } 
        // public bool 106 { get; set; } 
        // public bool 107 { get; set; } 
        // public bool 108 { get; set; } 
        // public bool 11 { get; set; } 
        // public bool 112 { get; set; } 
        // public bool 113 { get; set; } 
        // public bool 114 { get; set; } 
        // public bool 116 { get; set; } 
        // public bool 119 { get; set; } 
        // public bool 12 { get; set; } 
        // public bool 120 { get; set; } 
        // public bool 123 { get; set; } 
        // public bool 126 { get; set; } 
        // public bool 128 { get; set; } 
        // public bool 13 { get; set; } 
        // public bool 131 { get; set; } 
        // public bool 132 { get; set; } 
        // public bool 137 { get; set; } 
        // public bool 14 { get; set; } 
        // public bool 140 { get; set; } 
        // public bool 142 { get; set; } 
        // public bool 146 { get; set; } 
        // public bool 147 { get; set; } 
        // public bool 149 { get; set; } 
        // public bool 15 { get; set; } 
        // public bool 150 { get; set; } 
        // public bool 151 { get; set; } 
        // public bool 152 { get; set; } 
        // public bool 153 { get; set; } 
        // public bool 154 { get; set; } 
        // public bool 156 { get; set; } 
        // public bool 157 { get; set; } 
        // public bool 159 { get; set; } 
        // public bool 16 { get; set; } 
        // public bool 160 { get; set; } 
        // public bool 18 { get; set; } 
        // public bool 19 { get; set; } 
        // public bool 23 { get; set; } 
        // public bool 24 { get; set; } 
        // public bool 26 { get; set; } 
        // public bool 27 { get; set; } 
        // public bool 28 { get; set; } 
        // public bool 29 { get; set; } 
        // public bool 31 { get; set; } 
        // public bool 32 { get; set; } 
        // public bool 34 { get; set; } 
        // public bool 35 { get; set; } 
        // public bool 38 { get; set; } 
        // public bool 4 { get; set; } 
        // public bool 40 { get; set; } 
        // public bool 41 { get; set; } 
        // public bool 43 { get; set; } 
        // public bool 5 { get; set; } 
        // public bool 59 { get; set; } 
        // public bool 6 { get; set; } 
        // public bool 61 { get; set; } 
        // public bool 62 { get; set; } 
        // public bool 63 { get; set; } 
        // public bool 64 { get; set; } 
        // public bool 65 { get; set; } 
        // public bool 67 { get; set; } 
        // public bool 68 { get; set; } 
        // public bool 69 { get; set; } 
        // public bool 7 { get; set; } 
        // public bool 71 { get; set; } 
        // public bool 73 { get; set; } 
        // public bool 74 { get; set; } 
        // public bool 75 { get; set; } 
        // public bool 78 { get; set; } 
        // public bool 79 { get; set; } 
        // public bool 8 { get; set; } 
        // public bool 81 { get; set; } 
        // public bool 82 { get; set; } 
        // public bool 84 { get; set; } 
        // public bool 86 { get; set; } 
        // public bool 9 { get; set; } 
        // public bool 91 { get; set; } 
        // public bool 95 { get; set; } 
        // public bool 97 { get; set; } 
    }

    public class P
    {
    }

    public class AppUpsell
    {
        public string g { get; set; }
        public P p { get; set; }
    }

    public class P2
    {
    }

    public class IglAppUpsell
    {
        public string g { get; set; }
        public P2 p { get; set; }
    }

    public class P3
    {
    }

    public class Notif
    {
        public string g { get; set; }
        public P3 p { get; set; }
    }

    public class P4
    {
    }

    public class Onetaplogin
    {
        public string g { get; set; }
        public P4 p { get; set; }
    }

    public class P5
    {
    }

    public class FelixClearFbCookie
    {
        public string g { get; set; }
        public P5 p { get; set; }
    }

    public class P6
    {
    }

    public class FelixCreationDurationLimits
    {
        public string g { get; set; }
        public P6 p { get; set; }
    }

    public class P7
    {
    }

    public class FelixCreationFbCrossposting
    {
        public string g { get; set; }
        public P7 p { get; set; }
    }

    public class P8
    {
    }

    public class FelixCreationFbCrosspostingV2
    {
        public string g { get; set; }
        public P8 p { get; set; }
    }

    public class P9
    {
    }

    public class FelixCreationValidation
    {
        public string g { get; set; }
        public P9 p { get; set; }
    }

    public class P10
    {
    }

    public class PostOptions
    {
        public string g { get; set; }
        public P10 p { get; set; }
    }

    public class P11
    {
    }

    public class StickerTray
    {
        public string g { get; set; }
        public P11 p { get; set; }
    }

    public class P12
    {
    }

    public class WebSentry
    {
        public string g { get; set; }
        public P12 p { get; set; }
    }

    // public class P13    {
    //     public bool 9 { get; set; } 
    // }

    public class L
    {
    }

    // public class 0    {
    //     public P13 p { get; set; } 
    //     public L l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P14    {
    //     public bool 0 { get; set; } 
    // }

    public class L2
    {
    }

    // public class 100    {
    //     public P14 p { get; set; } 
    //     public L2 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    public class P15
    {
        // public bool 0 { get; set; } 
        // public bool 1 { get; set; } 
    }

    public class L3
    {
    }

    // public class 101    {
    //     public P15 p { get; set; } 
    //     public L3 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P16    {
    //     public bool 0 { get; set; } 
    // }

    public class L4
    {
    }

    // public class 102    {
    //     public P16 p { get; set; } 
    //     public L4 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P17    {
    //     public bool 1 { get; set; } 
    // }

    public class L5
    {
    }

    // public class 103    {
    //     public P17 p { get; set; } 
    //     public L5 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P18    {
    //     public bool 0 { get; set; } 
    // }

    public class L6
    {
    }

    // public class 104    {
    //     public P18 p { get; set; } 
    //     public L6 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P19    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    // }

    public class L7
    {
    }

    // public class 108    {
    //     public P19 p { get; set; } 
    //     public L7 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    public class P20
    {
    }

    public class L8
    {
    }

    // public class 109    {
    //     public P20 p { get; set; } 
    //     public L8 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P21    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    // }

    public class L9
    {
    }

    // public class 111    {
    //     public P21 p { get; set; } 
    //     public L9 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P22    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    //     public bool 4 { get; set; } 
    //     public bool 5 { get; set; } 
    //     public bool 7 { get; set; } 
    //     public bool 8 { get; set; } 
    // }

    // public class L10    {
    // }

    // public class 113    {
    //     public P22 p { get; set; } 
    //     public L10 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P23    {
    //     public bool 1 { get; set; } 
    //     public int 2 { get; set; } 
    // }

    // public class L11    {
    // }

    // public class 116    {
    //     public P23 p { get; set; } 
    //     public L11 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P24    {
    //     public bool 0 { get; set; } 
    // }

    // public class L12    {
    // }

    // public class 117    {
    //     public P24 p { get; set; } 
    //     public L12 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P25    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    // }

    // public class L13    {
    // }

    // public class 118    {
    //     public P25 p { get; set; } 
    //     public L13 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P26    {
    //     public bool 0 { get; set; } 
    // }

    // public class L14    {
    // }

    // public class 119    {
    //     public P26 p { get; set; } 
    //     public L14 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P27    {
    //     public int 0 { get; set; } 
    // }

    // public class L15    {
    // }

    // public class 12    {
    //     public P27 p { get; set; } 
    //     public L15 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P28    {
    //     public bool 0 { get; set; } 
    // }

    // public class L16    {
    // }

    // public class 121    {
    //     public P28 p { get; set; } 
    //     public L16 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P29    {
    //     public bool 0 { get; set; } 
    // }

    // public class L17    {
    // }

    // public class 122    {
    //     public P29 p { get; set; } 
    //     public L17 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P30    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    // }

    // public class L18    {
    // }

    // public class 123    {
    //     public P30 p { get; set; } 
    //     public L18 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P31    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    // }

    // public class L19    {
    // }

    // public class 124    {
    //     public P31 p { get; set; } 
    //     public L19 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P32    {
    //     public bool 0 { get; set; } 
    // }

    // public class L20    {
    // }

    // public class 125    {
    //     public P32 p { get; set; } 
    //     public L20 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P33    {
    //     public bool 0 { get; set; } 
    // }

    // public class L21    {
    // }

    // public class 126    {
    //     public P33 p { get; set; } 
    //     public L21 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P34    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    // }

    // public class L22    {
    // }

    // public class 127    {
    //     public P34 p { get; set; } 
    //     public L22 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P35    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    // }

    // public class L23    {
    // }

    // public class 128    {
    //     public P35 p { get; set; } 
    //     public L23 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P36    {
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    // }

    // public class L24    {
    //     public bool 2 { get; set; } 
    // }

    // public class 129    {
    //     public P36 p { get; set; } 
    //     public L24 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P37    {
    //     public bool 0 { get; set; } 
    // }

    // public class L25    {
    // }

    // public class 13    {
    //     public P37 p { get; set; } 
    //     public L25 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P38    {
    //     public bool 2 { get; set; } 
    //     public bool 3 { get; set; } 
    //     public bool 4 { get; set; } 
    // }

    // public class L26    {
    // }

    // public class 131    {
    //     public P38 p { get; set; } 
    //     public L26 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P39    {
    //     public bool 0 { get; set; } 
    // }

    // public class L27    {
    // }

    // public class 132    {
    //     public P39 p { get; set; } 
    //     public L27 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P40    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    //     public bool 3 { get; set; } 
    // }

    // public class L28    {
    // }

    // public class 135    {
    //     public P40 p { get; set; } 
    //     public L28 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P41    {
    // }

    // public class L29    {
    // }

    // public class 137    {
    //     public P41 p { get; set; } 
    //     public L29 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P42    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    // }

    // public class L30    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    // }

    // public class 140    {
    //     public P42 p { get; set; } 
    //     public L30 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P43    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    // }

    // public class L31    {
    // }

    // public class 141    {
    //     public P43 p { get; set; } 
    //     public L31 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P44    {
    //     public bool 0 { get; set; } 
    // }

    // public class L32    {
    // }

    // public class 142    {
    //     public P44 p { get; set; } 
    //     public L32 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P45    {
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    //     public bool 3 { get; set; } 
    //     public bool 4 { get; set; } 
    // }

    // public class L33    {
    // }

    // public class 143    {
    //     public P45 p { get; set; } 
    //     public L33 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P46    {
    //     public bool 0 { get; set; } 
    // }

    // public class L34    {
    // }

    // public class 16    {
    //     public P46 p { get; set; } 
    //     public L34 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P47    {
    //     public bool 2 { get; set; } 
    // }

    // public class L35    {
    // }

    // public class 21    {
    //     public P47 p { get; set; } 
    //     public L35 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P48    {
    //     public bool 1 { get; set; } 
    //     public double 10 { get; set; } 
    //     public int 11 { get; set; } 
    //     public int 12 { get; set; } 
    //     public bool 13 { get; set; } 
    //     public double 2 { get; set; } 
    //     public double 3 { get; set; } 
    //     public double 4 { get; set; } 
    // }

    // public class L36    {
    // }

    // public class 22    {
    //     public P48 p { get; set; } 
    //     public L36 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P49    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    // }

    // public class L37    {
    // }

    // public class 23    {
    //     public P49 p { get; set; } 
    //     public L37 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P50    {
    // }

    // public class L38    {
    // }

    // public class 25    {
    //     public P50 p { get; set; } 
    //     public L38 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P51    {
    //     public string 0 { get; set; } 
    // }

    // public class L39    {
    // }

    // public class 26    {
    //     public P51 p { get; set; } 
    //     public L39 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P52    {
    //     public bool 0 { get; set; } 
    // }

    // public class L40    {
    // }

    // public class 28    {
    //     public P52 p { get; set; } 
    //     public L40 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P53    {
    // }

    // public class L41    {
    // }

    // public class 29    {
    //     public P53 p { get; set; } 
    //     public L41 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P54    {
    // }

    // public class L42    {
    // }

    // public class 31    {
    //     public P54 p { get; set; } 
    //     public L42 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P55    {
    // }

    // public class L43    {
    // }

    // public class 33    {
    //     public P55 p { get; set; } 
    //     public L43 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P56    {
    //     public bool 0 { get; set; } 
    // }

    // public class L44    {
    // }

    // public class 34    {
    //     public P56 p { get; set; } 
    //     public L44 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P57    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    //     public bool 3 { get; set; } 
    //     public bool 4 { get; set; } 
    // }

    // public class L45    {
    // }

    // public class 36    {
    //     public P57 p { get; set; } 
    //     public L45 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P58    {
    //     public bool 0 { get; set; } 
    // }

    // public class L46    {
    // }

    // public class 37    {
    //     public P58 p { get; set; } 
    //     public L46 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P59    {
    //     public bool 0 { get; set; } 
    //     public bool 14 { get; set; } 
    //     public bool 8 { get; set; } 
    // }

    // public class L47    {
    // }

    // public class 39    {
    //     public P59 p { get; set; } 
    //     public L47 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P60    {
    //     public bool 3 { get; set; } 
    // }

    // public class L48    {
    // }

    // public class 41    {
    //     public P60 p { get; set; } 
    //     public L48 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P61    {
    //     public bool 0 { get; set; } 
    // }

    // public class L49    {
    // }

    // public class 42    {
    //     public P61 p { get; set; } 
    //     public L49 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P62    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    // }

    // public class L50    {
    // }

    // public class 43    {
    //     public P62 p { get; set; } 
    //     public L50 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P63    {
    //     public string 1 { get; set; } 
    //     public double 2 { get; set; } 
    // }

    // public class L51    {
    // }

    // public class 44    {
    //     public P63 p { get; set; } 
    //     public L51 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P64    {
    //     public bool 13 { get; set; } 
    //     public int 17 { get; set; } 
    //     public bool 32 { get; set; } 
    //     public bool 33 { get; set; } 
    //     public bool 35 { get; set; } 
    //     public string 36 { get; set; } 
    //     public bool 37 { get; set; } 
    //     public bool 38 { get; set; } 
    //     public string 40 { get; set; } 
    //     public string 45 { get; set; } 
    // }

    // public class L52    {
    // }

    // public class 45    {
    //     public P64 p { get; set; } 
    //     public L52 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P65    {
    //     public bool 0 { get; set; } 
    // }

    // public class L53    {
    // }

    // public class 46    {
    //     public P65 p { get; set; } 
    //     public L53 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P66    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 10 { get; set; } 
    //     public bool 11 { get; set; } 
    //     public bool 2 { get; set; } 
    //     public bool 3 { get; set; } 
    //     public bool 9 { get; set; } 
    // }

    // public class L54    {
    // }

    // public class 47    {
    //     public P66 p { get; set; } 
    //     public L54 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P67    {
    //     public bool 0 { get; set; } 
    // }

    // public class L55    {
    // }

    // public class 49    {
    //     public P67 p { get; set; } 
    //     public L55 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P68    {
    //     public bool 0 { get; set; } 
    // }

    // public class L56    {
    // }

    // public class 50    {
    //     public P68 p { get; set; } 
    //     public L56 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P69    {
    //     public bool 0 { get; set; } 
    // }

    // public class L57    {
    // }

    // public class 54    {
    //     public P69 p { get; set; } 
    //     public L57 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P70    {
    //     public double 0 { get; set; } 
    //     public bool 1 { get; set; } 
    // }

    // public class L58    {
    // }

    // public class 58    {
    //     public P70 p { get; set; } 
    //     public L58 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P71    {
    //     public bool 0 { get; set; } 
    // }

    // public class L59    {
    // }

    // public class 59    {
    //     public P71 p { get; set; } 
    //     public L59 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P72    {
    //     public bool 0 { get; set; } 
    // }

    // public class L60    {
    // }

    // public class 62    {
    //     public P72 p { get; set; } 
    //     public L60 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P73    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    //     public bool 3 { get; set; } 
    //     public bool 4 { get; set; } 
    //     public bool 5 { get; set; } 
    //     public bool 7 { get; set; } 
    // }

    // public class L61    {
    // }

    // public class 67    {
    //     public P73 p { get; set; } 
    //     public L61 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P74    {
    //     public bool 0 { get; set; } 
    // }

    // public class L62    {
    // }

    // public class 69    {
    //     public P74 p { get; set; } 
    //     public L62 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P75    {
    //     public string 1 { get; set; } 
    // }

    // public class L63    {
    // }

    // public class 71    {
    //     public P75 p { get; set; } 
    //     public L63 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P76    {
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    // }

    // public class L64    {
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    // }

    // public class 72    {
    //     public P76 p { get; set; } 
    //     public L64 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P77    {
    //     public bool 0 { get; set; } 
    // }

    // public class L65    {
    // }

    // public class 73    {
    //     public P77 p { get; set; } 
    //     public L65 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P78    {
    //     public bool 1 { get; set; } 
    //     public bool 12 { get; set; } 
    //     public bool 13 { get; set; } 
    //     public bool 15 { get; set; } 
    //     public bool 2 { get; set; } 
    //     public bool 3 { get; set; } 
    //     public bool 4 { get; set; } 
    //     public bool 7 { get; set; } 
    //     public bool 9 { get; set; } 
    // }

    // public class L66    {
    //     public bool 7 { get; set; } 
    // }

    // public class 74    {
    //     public P78 p { get; set; } 
    //     public L66 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P79    {
    //     public bool 0 { get; set; } 
    // }

    // public class L67    {
    // }

    // public class 75    {
    //     public P79 p { get; set; } 
    //     public L67 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P80    {
    //     public bool 1 { get; set; } 
    // }

    // public class L68    {
    // }

    // public class 77    {
    //     public P80 p { get; set; } 
    //     public L68 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P81    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    //     public bool 3 { get; set; } 
    //     public bool 5 { get; set; } 
    // }

    // public class L69    {
    // }

    // public class 78    {
    //     public P81 p { get; set; } 
    //     public L69 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P82    {
    //     public bool 3 { get; set; } 
    //     public bool 4 { get; set; } 
    // }

    // public class L70    {
    // }

    // public class 80    {
    //     public P82 p { get; set; } 
    //     public L70 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P83    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    //     public bool 2 { get; set; } 
    //     public bool 3 { get; set; } 
    //     public bool 4 { get; set; } 
    //     public bool 5 { get; set; } 
    //     public bool 6 { get; set; } 
    //     public bool 8 { get; set; } 
    // }

    // public class L71    {
    // }

    // public class 84    {
    //     public P83 p { get; set; } 
    //     public L71 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P84    {
    //     public bool 0 { get; set; } 
    //     public string 1 { get; set; } 
    // }

    // public class L72    {
    // }

    // public class 85    {
    //     public P84 p { get; set; } 
    //     public L72 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P85    {
    //     public bool 0 { get; set; } 
    // }

    // public class L73    {
    // }

    // public class 87    {
    //     public P85 p { get; set; } 
    //     public L73 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P86    {
    //     public bool 0 { get; set; } 
    // }

    // public class L74    {
    // }

    // public class 93    {
    //     public P86 p { get; set; } 
    //     public L74 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P87    {
    //     public bool 0 { get; set; } 
    //     public bool 1 { get; set; } 
    // }

    // public class L75    {
    // }

    // public class 95    {
    //     public P87 p { get; set; } 
    //     public L75 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    // public class P88    {
    //     public bool 1 { get; set; } 
    // }

    // public class L76    {
    // }

    // public class 98    {
    //     public P88 p { get; set; } 
    //     public L76 l { get; set; } 
    //     public bool qex { get; set; } 
    // }

    public class Qe
    {
        public AppUpsell app_upsell { get; set; }
        public IglAppUpsell igl_app_upsell { get; set; }
        public Notif notif { get; set; }
        public Onetaplogin onetaplogin { get; set; }
        public FelixClearFbCookie felix_clear_fb_cookie { get; set; }
        public FelixCreationDurationLimits felix_creation_duration_limits { get; set; }
        public FelixCreationFbCrossposting felix_creation_fb_crossposting { get; set; }
        public FelixCreationFbCrosspostingV2 felix_creation_fb_crossposting_v2 { get; set; }
        public FelixCreationValidation felix_creation_validation { get; set; }
        public PostOptions post_options { get; set; }
        public StickerTray sticker_tray { get; set; }
        public WebSentry web_sentry { get; set; }
        // public 0 0 { get; set; } 
        // public 100 100 { get; set; } 
        // public 101 101 { get; set; } 
        // public 102 102 { get; set; } 
        // public 103 103 { get; set; } 
        // public 104 104 { get; set; } 
        // public 108 108 { get; set; } 
        // public 109 109 { get; set; } 
        // public 111 111 { get; set; } 
        // public 113 113 { get; set; } 
        // public 116 116 { get; set; } 
        // public 117 117 { get; set; } 
        // public 118 118 { get; set; } 
        // public 119 119 { get; set; } 
        // public 12 12 { get; set; } 
        // public 121 121 { get; set; } 
        // public 122 122 { get; set; } 
        // public 123 123 { get; set; } 
        // public 124 124 { get; set; } 
        // public 125 125 { get; set; } 
        // public 126 126 { get; set; } 
        // public 127 127 { get; set; } 
        // public 128 128 { get; set; } 
        // public 129 129 { get; set; } 
        // public 13 13 { get; set; } 
        // public 131 131 { get; set; } 
        // public 132 132 { get; set; } 
        // public 135 135 { get; set; } 
        // public 137 137 { get; set; } 
        // public 140 140 { get; set; } 
        // public 141 141 { get; set; } 
        // public 142 142 { get; set; } 
        // public 143 143 { get; set; } 
        // public 16 16 { get; set; } 
        // public 21 21 { get; set; } 
        // public 22 22 { get; set; } 
        // public 23 23 { get; set; } 
        // public 25 25 { get; set; } 
        // public 26 26 { get; set; } 
        // public 28 28 { get; set; } 
        // public 29 29 { get; set; } 
        // public 31 31 { get; set; } 
        // public 33 33 { get; set; } 
        // public 34 34 { get; set; } 
        // public 36 36 { get; set; } 
        // public 37 37 { get; set; } 
        // public 39 39 { get; set; } 
        // public 41 41 { get; set; } 
        // public 42 42 { get; set; } 
        // public 43 43 { get; set; } 
        // public 44 44 { get; set; } 
        // public 45 45 { get; set; } 
        // public 46 46 { get; set; } 
        // public 47 47 { get; set; } 
        // public 49 49 { get; set; } 
        // public 50 50 { get; set; } 
        // public 54 54 { get; set; } 
        // public 58 58 { get; set; } 
        // public 59 59 { get; set; } 
        // public 62 62 { get; set; } 
        // public 67 67 { get; set; } 
        // public 69 69 { get; set; } 
        // public 71 71 { get; set; } 
        // public 72 72 { get; set; } 
        // public 73 73 { get; set; } 
        // public 74 74 { get; set; } 
        // public 75 75 { get; set; } 
        // public 77 77 { get; set; } 
        // public 78 78 { get; set; } 
        // public 80 80 { get; set; } 
        // public 84 84 { get; set; } 
        // public 85 85 { get; set; } 
        // public 87 87 { get; set; } 
        // public 93 93 { get; set; } 
        // public 95 95 { get; set; } 
        // public 98 98 { get; set; } 
    }

    public class ToCache
    {
        public Gatekeepers gatekeepers { get; set; }
        public Qe qe { get; set; }
        public bool probably_has_app { get; set; }
        public bool cb { get; set; }
    }

    public class Encryption
    {
        public string key_id { get; set; }
        public string public_key { get; set; }
        public string version { get; set; }
    }

    public class Root
    {
        public Config config { get; set; }
        public string country_code { get; set; }
        public string language_code { get; set; }
        public string locale { get; set; }
        public EntryData entry_data { get; set; }
        public string hostname { get; set; }
        public bool is_whitelisted_crawl_bot { get; set; }
        public string deployment_stage { get; set; }
        public string platform { get; set; }
        public string nonce { get; set; }
        public double mid_pct { get; set; }
        public ZeroData zero_data { get; set; }
        public int cache_schema_version { get; set; }
        public ServerChecks server_checks { get; set; }
        // public Knobx knobx { get; set; } 
        public ToCache to_cache { get; set; }
        public string device_id { get; set; }
        public string browser_push_pub_key { get; set; }
        public Encryption encryption { get; set; }
        public bool is_dev { get; set; }
        public object signal_collection_config { get; set; }
        public string rollout_hash { get; set; }
        public string bundle_variant { get; set; }
        public string frontend_env { get; set; }
    }

}
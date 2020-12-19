// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
using System.Collections.Generic;

namespace InstaShop.HastTags.Models.PerfilClass
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Config    {
        public string csrf_token { get; set; } 
        public object viewer { get; set; } 
        public object viewerId { get; set; } 
    }

    public class EdgeFollowedBy    {
        public int count { get; set; } 



    }

    public class EdgeFollow    {
        public int count { get; set; } 
    }

    public class EdgeMutualFollowedBy    {
        public int count { get; set; } 
        public List<object> edges { get; set; } 
    }

    public class PageInfo    {
        public bool has_next_page { get; set; } 
        public object end_cursor { get; set; } 
    }

    public class Dimensions    {
        public int height { get; set; } 
        public int width { get; set; } 
    }

    public class EdgeMediaToTaggedUser    {
        public List<object> edges { get; set; } 
    }

    public class Owner    {
        public string id { get; set; } 
        public string username { get; set; } 
    }

    public class DashInfo    {
        public bool is_dash_eligible { get; set; } 
        public object video_dash_manifest { get; set; } 
        public int number_of_qualities { get; set; } 
    }

    public class Node2    {
        public string text { get; set; } 
    }

    public class Edge2    {
        public Node2 node { get; set; } 
    }

    public class EdgeMediaToCaption    {
        public List<Edge2> edges { get; set; } 
    }

    public class EdgeMediaToComment    {
        public int count { get; set; } 
    }

    public class EdgeLikedBy    {
        public int count { get; set; } 
    }

    public class EdgeMediaPreviewLike    {
        public int count { get; set; } 
    }

    public class ThumbnailResource    {
        public string src { get; set; } 
        public int config_width { get; set; } 
        public int config_height { get; set; } 
    }

    public class FelixProfileGridCrop    {
        public double crop_left { get; set; } 
        public double crop_right { get; set; } 
        public double crop_top { get; set; } 
        public double crop_bottom { get; set; } 
    }

    public class Node    {
        public string __typename { get; set; } 
        public string id { get; set; } 
        public string shortcode { get; set; } 
        public Dimensions dimensions { get; set; } 
        public string display_url { get; set; } 
        public EdgeMediaToTaggedUser edge_media_to_tagged_user { get; set; } 
        public object fact_check_overall_rating { get; set; } 
        public object fact_check_information { get; set; } 
        public object gating_info { get; set; } 
        public object media_overlay_info { get; set; } 
        public string media_preview { get; set; } 
        public Owner owner { get; set; } 
        public bool is_video { get; set; } 
        public object accessibility_caption { get; set; } 
        public DashInfo dash_info { get; set; } 
        public bool has_audio { get; set; } 
        public string tracking_token { get; set; } 
        public string video_url { get; set; } 
        public int video_view_count { get; set; } 
        public EdgeMediaToCaption edge_media_to_caption { get; set; } 
        public EdgeMediaToComment edge_media_to_comment { get; set; } 
        public bool comments_disabled { get; set; } 
        public int taken_at_timestamp { get; set; } 
        public EdgeLikedBy edge_liked_by { get; set; } 
        public EdgeMediaPreviewLike edge_media_preview_like { get; set; } 
        public object location { get; set; } 
        public string thumbnail_src { get; set; } 
        public List<ThumbnailResource> thumbnail_resources { get; set; } 
        public FelixProfileGridCrop felix_profile_grid_crop { get; set; } 
        public object encoding_status { get; set; } 
        public bool is_published { get; set; } 
        public string product_type { get; set; } 
        public string title { get; set; } 
        public double video_duration { get; set; } 
    }

    public class Edge    {
        public Node node { get; set; } 
    }

    public class EdgeFelixVideoTimeline    {
        public int count { get; set; } 
        public PageInfo page_info { get; set; } 
        public List<Edge> edges { get; set; } 
    }

    public class PageInfo2    {
        public bool has_next_page { get; set; } 
        public string end_cursor { get; set; } 
    }

    public class Dimensions2    {
        public int height { get; set; } 
        public int width { get; set; } 
    }

    public class User2    {
        public string full_name { get; set; } 
        public string id { get; set; } 
        public bool is_verified { get; set; } 
        public string profile_pic_url { get; set; } 
        public string username { get; set; } 
    }

    public class Node4    {
        public User2 user { get; set; } 
        public double x { get; set; } 
        public double y { get; set; } 
    }

    public class Edge4    {
        public Node4 node { get; set; } 
    }

    public class EdgeMediaToTaggedUser2    {
        public List<Edge4> edges { get; set; } 
    }

    public class Owner2    {
        public string id { get; set; } 
        public string username { get; set; } 
    }

    public class Node5    {
        public string text { get; set; } 
    }

    public class Edge5    {
        public Node5 node { get; set; } 
    }

    public class EdgeMediaToCaption2    {
        public List<Edge5> edges { get; set; } 
    }

    public class EdgeMediaToComment2    {
        public int count { get; set; } 
    }

    public class EdgeLikedBy2    {
        public int count { get; set; } 
    }

    public class EdgeMediaPreviewLike2    {
        public int count { get; set; } 
    }

    public class Location    {
        public string id { get; set; } 
        public bool has_public_page { get; set; } 
        public string name { get; set; } 
        public string slug { get; set; } 
    }

    public class ThumbnailResource2    {
        public string src { get; set; } 
        public int config_width { get; set; } 
        public int config_height { get; set; } 
    }

    public class Dimensions3    {
        public int height { get; set; } 
        public int width { get; set; } 
    }

    public class User3    {
        public string full_name { get; set; } 
        public string id { get; set; } 
        public bool is_verified { get; set; } 
        public string profile_pic_url { get; set; } 
        public string username { get; set; } 
    }

    public class Node7    {
        public User3 user { get; set; } 
        public double x { get; set; } 
        public double y { get; set; } 
    }

    public class Edge7    {
        public Node7 node { get; set; } 
    }

    public class EdgeMediaToTaggedUser3    {
        public List<Edge7> edges { get; set; } 
    }

    public class Owner3    {
        public string id { get; set; } 
        public string username { get; set; } 
    }

    public class Node6    {
        public string __typename { get; set; } 
        public string id { get; set; } 
        public string shortcode { get; set; } 
        public Dimensions3 dimensions { get; set; } 
        public string display_url { get; set; } 
        public EdgeMediaToTaggedUser3 edge_media_to_tagged_user { get; set; } 
        public object fact_check_overall_rating { get; set; } 
        public object fact_check_information { get; set; } 
        public object gating_info { get; set; } 
        public object media_overlay_info { get; set; } 
        public string media_preview { get; set; } 
        public Owner3 owner { get; set; } 
        public bool is_video { get; set; } 
        public string accessibility_caption { get; set; } 
    }

    public class Edge6    {
        public Node6 node { get; set; } 
    }

    public class EdgeSidecarToChildren    {
        public List<Edge6> edges { get; set; } 
    }

    public class Node3    {
        public string __typename { get; set; } 
        public string id { get; set; } 
        public string shortcode { get; set; } 
        public Dimensions2 dimensions { get; set; } 
        public string display_url { get; set; } 
        public EdgeMediaToTaggedUser2 edge_media_to_tagged_user { get; set; } 
        public object fact_check_overall_rating { get; set; } 
        public object fact_check_information { get; set; } 
        public object gating_info { get; set; } 
        public object media_overlay_info { get; set; } 
        public string media_preview { get; set; } 
        public Owner2 owner { get; set; } 
        public bool is_video { get; set; } 
        public string accessibility_caption { get; set; } 
        public EdgeMediaToCaption2 edge_media_to_caption { get; set; } 
        public EdgeMediaToComment2 edge_media_to_comment { get; set; } 
        public bool comments_disabled { get; set; } 
        public int taken_at_timestamp { get; set; } 
        public EdgeLikedBy2 edge_liked_by { get; set; } 
        public EdgeMediaPreviewLike2 edge_media_preview_like { get; set; } 
        public Location location { get; set; } 
        public string thumbnail_src { get; set; } 
        public List<ThumbnailResource2> thumbnail_resources { get; set; } 
        public EdgeSidecarToChildren edge_sidecar_to_children { get; set; } 
    }

    public class Edge3    {
        public Node3 node { get; set; } 
    }

    public class EdgeOwnerToTimelineMedia    {
        public int count { get; set; } 
        public PageInfo2 page_info { get; set; } 
        public List<Edge3> edges { get; set; } 
    }

    public class PageInfo3    {
        public bool has_next_page { get; set; } 
        public object end_cursor { get; set; } 
    }

    public class EdgeSavedMedia    {
        public int count { get; set; } 
        public PageInfo3 page_info { get; set; } 
        public List<object> edges { get; set; } 
    }

    public class PageInfo4    {
        public bool has_next_page { get; set; } 
        public object end_cursor { get; set; } 
    }

    public class EdgeMediaCollections    {
        public int count { get; set; } 
        public PageInfo4 page_info { get; set; } 
        public List<object> edges { get; set; } 
    }

    public class EdgeRelatedProfiles    {
        public List<object> edges { get; set; } 
    }

    public class User    {
        public string biography { get; set; } 
        public bool blocked_by_viewer { get; set; } 
        public object business_email { get; set; } 
        public object restricted_by_viewer { get; set; } 
        public bool country_block { get; set; } 
        public string external_url { get; set; } 
        public string external_url_linkshimmed { get; set; } 
        public EdgeFollowedBy edge_followed_by { get; set; } 
        public bool followed_by_viewer { get; set; } 
        public EdgeFollow edge_follow { get; set; } 
        public bool follows_viewer { get; set; } 
        public string full_name { get; set; } 
        public bool has_ar_effects { get; set; } 
        public bool has_clips { get; set; } 
        public bool has_guides { get; set; } 
        public bool has_channel { get; set; } 
        public bool has_blocked_viewer { get; set; } 
        public int highlight_reel_count { get; set; } 
        public bool has_requested_viewer { get; set; } 
        public string id { get; set; } 
        public bool is_business_account { get; set; } 
        public bool is_joined_recently { get; set; } 
        public object business_category_name { get; set; } 
        public object overall_category_name { get; set; } 
        public object category_enum { get; set; } 
        public bool is_private { get; set; } 
        public bool is_verified { get; set; } 
        public EdgeMutualFollowedBy edge_mutual_followed_by { get; set; } 
        public string profile_pic_url { get; set; } 
        public string profile_pic_url_hd { get; set; } 
        public bool requested_by_viewer { get; set; } 
        public string username { get; set; } 
        public object connected_fb_page { get; set; } 
        public EdgeFelixVideoTimeline edge_felix_video_timeline { get; set; } 
        public EdgeOwnerToTimelineMedia edge_owner_to_timeline_media { get; set; } 
        public EdgeSavedMedia edge_saved_media { get; set; } 
        public EdgeMediaCollections edge_media_collections { get; set; } 
        public EdgeRelatedProfiles edge_related_profiles { get; set; } 
    }

    public class Graphql    {
        public User user { get; set; } 
    }

    public class ProfilePage    {
        public string logging_page_id { get; set; } 
        public bool show_suggested_profiles { get; set; } 
        public bool show_follow_dialog { get; set; } 
        public Graphql graphql { get; set; } 
        public object toast_content_on_load { get; set; } 
        public bool show_view_shop { get; set; } 
    }

    public class EntryData    {
        public List<ProfilePage> ProfilePage { get; set; } 
    }

    public class ZeroData    {
    }

    public class ServerChecks    {
    }

       public class P    {
    }

    public class AppUpsell    {
        public string g { get; set; } 
        public P p { get; set; } 
    }

    public class P2    {
    }

    public class IglAppUpsell    {
        public string g { get; set; } 
        public P2 p { get; set; } 
    }

    public class P3    {
    }

    public class Notif    {
        public string g { get; set; } 
        public P3 p { get; set; } 
    }

    public class P4    {
    }

    public class Onetaplogin    {
        public string g { get; set; } 
        public P4 p { get; set; } 
    }

    public class P5    {
    }

    public class FelixClearFbCookie    {
        public string g { get; set; } 
        public P5 p { get; set; } 
    }

    public class P6    {
    }

    public class FelixCreationDurationLimits    {
        public string g { get; set; } 
        public P6 p { get; set; } 
    }

    public class P7    {
    }

    public class FelixCreationFbCrossposting    {
        public string g { get; set; } 
        public P7 p { get; set; } 
    }

    public class P8    {
    }

    public class FelixCreationFbCrosspostingV2    {
        public string g { get; set; } 
        public P8 p { get; set; } 
    }

    public class P9    {
    }

    public class FelixCreationValidation    {
        public string g { get; set; } 
        public P9 p { get; set; } 
    }

    public class P10    {
    }

    public class PostOptions    {
        public string g { get; set; } 
        public P10 p { get; set; } 
    }

    public class P11    {
    }

    public class StickerTray    {
        public string g { get; set; } 
        public P11 p { get; set; } 
    }

    public class P12    {
    }

    public class WebSentry    {
        public string g { get; set; } 
        public P12 p { get; set; } 
    }

 
    public class Qe    {
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

    }

    public class ToCache    {
        public Qe qe { get; set; } 
        public bool probably_has_app { get; set; } 
        public bool cb { get; set; } 
    }

    public class Encryption    {
        public string key_id { get; set; } 
        public string public_key { get; set; } 
        public string version { get; set; } 
    }

    public class Root    {
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
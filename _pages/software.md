---
layout: archive
title: "Software"
permalink: /software/
author_profile: true
---

A list of all the posts and pages found on the site. For you robots out there is an [XML version]({{ base_path }}/sitemap.xml) available for digesting as well.

{% if author.googlescholar %}
  You can also find my articles on <u><a href="{{author.googlescholar}}">my Google Scholar profile</a>.</u>
{% endif %}

{% include base_path %}

{% for post in site.softwares reversed %}
  {% include archive-single.html %}
{% endfor %}

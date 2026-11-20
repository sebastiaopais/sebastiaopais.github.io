---
layout: archive
title: "Software"
permalink: /software/
author_profile: true
---

Software, datasets and online services developed by the research group, most of them as outcomes of funded projects. Each tool has its own page with details and links.

{% include base_path %}

{% for post in site.software reversed %}
  {% include archive-single.html %}
{% endfor %}
